using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using ReaLTaiizor.Controls;
using SpiceSharp;
using SpiceSharp.Components;
using System.Data.SQLite;
using System.Data;
using SpiceSharp.Simulations;
using System.Text;
using System.Security.Cryptography;

namespace CircuitCraft
{
    public struct TempUserInformation
    {
        public string Username { get; set; }
        public byte[] ProfileImage { get; set; }
        public int CircuitsCompleted { get; set; }
        public int BurnedResistors { get; set; }
        public int BurnedLed { get; set; }
        public int Rating { get; set; }
    }
    internal static class Program
    {
        public static bool isFullScreen = false;
        public static FormWindowState originalWindowState;
        public static Rectangle originalBounds;

        public static Media mainMenuMedia;
        private static string GetLibVLCPath()
        {
            var architectureFolder = IntPtr.Size == 8 ? "win-x64" : "win-x86";
            var currentDirectory = AppContext.BaseDirectory;
            return Path.Combine(currentDirectory, "libvlc", architectureFolder);
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var libvlcPath = GetLibVLCPath();
            Core.Initialize(libvlcPath);

            ApplicationConfiguration.Initialize();
            DataClass.ConnectionDatabase();
            Application.Run(new MainGamePrototype());
        }

        public static int CalculateRating(int C, int R, int L)
        {
            double weightC = 10.0;
            double weightR = 1.0;
            double weightL = 2.0;
            double scaleFactor = 5.0; 
            double baseScore = 100; 

            double rating;

            if (C > 0)
            {
                double totalPenaltyValue = (weightR * R) + (weightL * L);
                double penaltyRatio = totalPenaltyValue / C; 
                rating = (weightC * C) - (penaltyRatio * scaleFactor);
            }
            else
            {
                rating = baseScore - (weightR * R) - (weightL * L);
            }

            return Convert.ToInt32(Math.Max(0, rating));
        }
    }

    public static class DataClass
    {
        private static string databaseName = "Database.db"; 
        private static string connectionString = $"Data Source={databaseName};Version=3;Foreign Keys=true;";
        public static string username;
        public static byte[] profileImageBytes;


        private static int _highestLevelReached;
        private static int _highestJoulesObtained;
        private static int _unpoweredLeds;
        private static int _burnedLeds;
        private static int _diodeBlocked;
        private static int _circuitOverflowed;
        private static int _rating;

        public static int HighestLevelReached
        {
            get { return _highestLevelReached; }
            set
            {
                _highestLevelReached = value;
                Rating = Program.CalculateRating(_highestLevelReached, _unpoweredLeds, _burnedLeds);
                UpdateUserInformation("CircuitsCompleted", value);
            }
        }
        public static int UnpoweredLeds
        {
            get { return _unpoweredLeds; }
            set
            {
                _unpoweredLeds = value;
                Rating = Program.CalculateRating(_highestLevelReached, _unpoweredLeds, _burnedLeds);
                UpdateUserInformation("BurnedResistors", value);
            }
        }
        public static int BurnedLeds
        {
            get { return _burnedLeds; }
            set
            {
                _burnedLeds = value;
                Rating = Program.CalculateRating(_highestLevelReached, _unpoweredLeds, _burnedLeds);
                UpdateUserInformation("BurnedLed", value);
            }
        }
        public static int Rating
        {
            get { return _rating; }
            set
            {
                _rating = value;
                UpdateUserInformation("Rating", value);
            }
        }

        private static int _musicVolume;
        private static int _soundVolume;
        public static int MusicVolume
        {
            get { return _musicVolume; }
            set
            {
                _musicVolume = value;
                UpdateUserInformation("MusicVolume", value);
            }
        }
        public static int SoundVolume
        {
            get { return _soundVolume; }
            set
            {
                _soundVolume = value;
                UpdateUserInformation("SoundVolume", value);
            }
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword.Equals(storedHash, StringComparison.OrdinalIgnoreCase);
        }

        public static void ResetUserData()
        {
            username = string.Empty;
            profileImageBytes = null;
            HighestLevelReached = 0;
            UnpoweredLeds = 0;
            BurnedLeds = 0;
            Rating = 0;
            MusicVolume = 100;
            SoundVolume = 100;
        }

        public static void ConnectionDatabase()
        {
            string createUserTableSql = @"
                    CREATE TABLE IF NOT EXISTS User (
                        Username TEXT PRIMARY KEY NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        ProfileImage BLOB
                    );";

            string createStatsTableSql = @"
                    CREATE TABLE IF NOT EXISTS GameStatistics (
                        Username TEXT PRIMARY KEY NOT NULL UNIQUE,
                        HighestLevelReached INTEGER NOT NULL DEFAULT 0,
                        HighestJoulesObtained INTEGER NOT NULL DEFAULT 0,
                        UnpoweredLed INTEGER NOT NULL DEFAULT 0,
                        BurnedLed INTEGER NOT NULL DEFAULT 0,
                        DiodeBlocked INTEGER NOT NULL DEFAULT 0,
                        CircuitOverflowed INTEGER NOT NULL DEFAULT 0,
                        Rating INTEGER NOT NULL DEFAULT 0,
                        FOREIGN KEY (Username) REFERENCES User(Username)
                            ON DELETE CASCADE -- Automatically delete stats if user is deleted
                    );";

            string createSettingsTableSql = @"
                    CREATE TABLE IF NOT EXISTS GameSettings (
                        Username TEXT PRIMARY KEY NOT NULL UNIQUE,
                        MusicVolume INTEGER NOT NULL DEFAULT 100,
                        SoundVolume INTEGER NOT NULL DEFAULT 100,
                        FOREIGN KEY (Username) REFERENCES User(Username)
                            ON DELETE CASCADE -- Automatically delete settings if user is deleted
                    );";
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand command = new SQLiteCommand(connection))
                    {
                        command.CommandText = createUserTableSql;
                        command.ExecuteNonQuery();

                        command.CommandText = createStatsTableSql;
                        command.ExecuteNonQuery(); 

                        command.CommandText = createSettingsTableSql;
                        command.ExecuteNonQuery();
                    }
                } 
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show($"Error connecting to SQLite database: {ex.Message}");
            }
        }

        public static bool RegisterUser(string username, string passwordText)
        {
            string passwordHash = HashPassword(passwordText);
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string insertUserSql = @"
                    INSERT INTO User (Username, PasswordHash, ProfileImage)
                    VALUES (@Username, @PasswordHash, @ProfileImage);";

                    using (SQLiteCommand insertUserCommand = new SQLiteCommand(insertUserSql, connection))
                    {
                        insertUserCommand.Parameters.AddWithValue("@Username", username);
                        insertUserCommand.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        insertUserCommand.Parameters.AddWithValue("@ProfileImage", DBNull.Value);
                        insertUserCommand.ExecuteNonQuery();
                        //MessageBox.Show($"User '{username}' registered successfully.");
                    }

                    string insertStatsSql = @"
                        INSERT INTO GameStatistics (Username)
                        VALUES (@Username);";

                    using (SQLiteCommand insertStatsCommand = new SQLiteCommand(insertStatsSql, connection))
                    {
                        insertStatsCommand.Parameters.AddWithValue("@Username", username);
                        insertStatsCommand.ExecuteNonQuery();
                    }

                    string insertSettingsSql = @"
                        INSERT INTO GameSettings (Username)
                        VALUES (@Username);";

                    using (SQLiteCommand insertSettingsCommand = new SQLiteCommand(insertSettingsSql, connection))
                    {
                        insertSettingsCommand.Parameters.AddWithValue("@Username", username);
                        insertSettingsCommand.ExecuteNonQuery();
                    }
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show($"Error inserting user into SQLite database: {ex.Message}");
                return false;
            }
        }

        public static bool AuthenticateUser(string username, string passwordText)
        {
            string passwordHash = HashPassword(passwordText);
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string selectUserSql = @"
                    SELECT PasswordHash
                    FROM User
                    WHERE Username = @Username;";

                    using (SQLiteCommand selectUserCommand = new SQLiteCommand(selectUserSql, connection))
                    {
                        selectUserCommand.Parameters.AddWithValue("@Username", username);
                        string storedHash = selectUserCommand.ExecuteScalar() as string;
                        if (storedHash == null)
                        {
                            //MessageBox.Show($"User '{username}' not found.");
                            return false;
                        }

                        if (VerifyPassword(passwordText, storedHash))
                        {
                            //MessageBox.Show($"User '{username}' authenticated successfully.");
                            return true;
                        }
                        else
                        {
                            //MessageBox.Show($"Incorrect password for user '{username}'.");
                            return false;
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show($"Error authenticating user in SQLite database: {ex.Message}");
                return false;
            }
        }

        public static void AqcuireUserInformation()
        {                    
            string selectUserDataSql = @"
        SELECT 
            U.Username, 
            U.ProfileImage, 
            GS.HighestLevelReached, 
            GS.HighestJoulesObtained, 
            GS.UnpoweredLed, 
            GS.BurnedLed, 
            GS.DiodeBlocked,
            GS.CircuitOverflowed,
            GS.Rating,
            SETT.MusicVolume, 
            SETT.SoundVolume
        FROM User U
        LEFT JOIN GameStatistics GS ON U.Username = GS.Username
        LEFT JOIN GameSettings SETT ON U.Username = SETT.Username
        WHERE U.Username = @Username;";

            string connectionString = $"Data Source={databaseName};Version=3;"; // Connection string

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand selectUserCommand = new SQLiteCommand(selectUserDataSql, connection))
                {
                    selectUserCommand.Parameters.AddWithValue("@Username", username);

                    using (SQLiteDataReader reader = selectUserCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            username = reader.GetString(0);

                            profileImageBytes = reader["ProfileImage"] as byte[];

                            _highestLevelReached = reader.GetInt32(2);
                            _highestJoulesObtained = reader.GetInt32(3);
                            _unpoweredLeds = reader.GetInt32(4);
                            _burnedLeds = reader.GetInt32(5);
                            _diodeBlocked = reader.GetInt32(6);
                            _circuitOverflowed = reader.GetInt32(7);
                            _rating = reader.GetInt32(8);
                                  
                            _musicVolume = reader.GetInt32(9);         
                            _soundVolume = reader.GetInt32(10);          
                        }
                        else
                        {
                            // MessageBox.Show($"User '{username}' not found.");
                        }
                    }
                }
            }
        }


        public static bool UpdateUserInformation(string fieldToUpdate, object newValue)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    if (!UpdateUserField(connection, username, fieldToUpdate, newValue))
                    {
                        throw new SQLiteException("Error updating user information.");
                    }
                }
                return true;
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show($"Error updating user information into SQLite database: {ex.Message}");
                return false;
            }
        }

        private static bool UpdateUserField(SQLiteConnection connection, string usernameToUpdate, string fieldToUpdate, object newValue)
        {
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
            {
                //MessageBox.Show("Error: Database connection is not open or valid.");
                return false;
            }

            string tableName = "";
            string columnName = fieldToUpdate;
            object processedValue = newValue;
            switch (fieldToUpdate.ToLower())
            {
                case "passwordhash":
                case "password":
                    tableName = "User";
                    columnName = "PasswordHash";
                    if (newValue is string pwdString)
                    {
                        processedValue = HashPassword(pwdString); 
                    }
                    else
                    {
                        //Console.WriteLine("Error: Invalid value type provided for password update.");
                        return false; 
                    }
                    break;
                case "profileimage":
                    tableName = "User";
                    processedValue = (newValue is byte[] || newValue == null) ? (newValue ?? DBNull.Value) : newValue;
                    if (!(processedValue is byte[] || processedValue == DBNull.Value))
                    {
                        //Console.WriteLine("Error: Invalid value type provided for ProfileImage update. Expected byte[] or null.");
                        return false;
                    }
                    break;

                case "highestlevelreached":
                case "highestjoulesobtained":
                case "unpoweredled":
                case "burnedled":
                case "diodeblocked":
                case "circuitoverflowed":
                case "rating":
                    tableName = "GameStatistics";
                    break;


                case "musicvolume":
                case "soundvolume":
                    tableName = "GameSettings";
                    break;
                default:
                    MessageBox.Show($"Error: Field '{fieldToUpdate}' is not a valid field to update.");
                    return false;
            }

            string updateSql = $"UPDATE {tableName} SET {columnName} = @NewValue WHERE Username = @Username;";

            using (SQLiteCommand updateCommand = new SQLiteCommand(updateSql, connection))
            {
                updateCommand.Parameters.AddWithValue("@NewValue", processedValue);
                updateCommand.Parameters.AddWithValue("@Username", usernameToUpdate);
                try
                {
                    int rowsAffected = updateCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (SQLiteException ex)
                {
                    //MessageBox.Show($"Error updating field '{fieldToUpdate}' for user '{usernameToUpdate}': {ex.Message}");
                    return false;
                }
            }

        }

        public static void DeleteUser()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string deleteUserSql = "DELETE FROM User WHERE Username = @Username;";
                    using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteUserSql, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@Username", username);

                        int rowsAffected = deleteCommand.ExecuteNonQuery(); // Execute the DELETE command

                        if (rowsAffected > 0)
                        {
                            //MessageBox.Show($"User '{username}' deleted successfully.");
                        }
                        else
                        {
                            //MessageBox.Show($"User '{username}' not found in the database.");
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show($"Error deleting user from SQLite database: {ex.Message}");
            }
        }

        public static List<TempUserInformation> SortedUsersByRating()
        {
            List<TempUserInformation> sortedUsers = new List<TempUserInformation>();
            string selectSortedUsersSql = @"
        SELECT 
            U.Username, 
            U.ProfileImage, 
            GS.HighestLevelReached, 
            GS.HighestJoulesObtained, 
            GS.UnpoweredLed, 
            GS.BurnedLed, 
            GS.DiodeBlocked,
            GS.CircuitOverflowed,
            GS.Rating, 
            SETT.MusicVolume, 
            SETT.SoundVolume
        FROM User U
        LEFT JOIN GameStatistics GS ON U.Username = GS.Username
        LEFT JOIN GameSettings SETT ON U.Username = SETT.Username
        ORDER BY GS.Rating DESC;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (SQLiteCommand selectSortedUsersCommand = new SQLiteCommand(selectSortedUsersSql, connection))
                    {
                        using (SQLiteDataReader reader = selectSortedUsersCommand.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("No users found in the database.");
                                return sortedUsers;
                            }

                            while (reader.Read())
                            {
                                TempUserInformation tempUserInformation = new TempUserInformation();
                                tempUserInformation.Username = reader.GetString(0);
                                tempUserInformation.ProfileImage = reader["ProfileImage"] as byte[];
                                tempUserInformation.CircuitsCompleted = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                                tempUserInformation.BurnedResistors = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                                tempUserInformation.BurnedLed = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                                tempUserInformation.Rating = reader.IsDBNull(5) ? 0 : reader.GetInt32(5);

                                sortedUsers.Add(tempUserInformation);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
            }
            return sortedUsers;
        }


        public static void ResetUser()
        {
            UpdateUserInformation("HighestLevelReached", 0);
            UpdateUserInformation("HighestJoulesObtained", 0);
            UpdateUserInformation("UnpoweredLed", 0);
            UpdateUserInformation("BurnedLed", 0);
            UpdateUserInformation("DiodeBlocked", 0);
            UpdateUserInformation("CircuitOverflowed", 0);
            UpdateUserInformation("Rating", 0);
        }

        public static LeaderboardsForm LeaderboardsForm
        {
            get => default;
            set
            {
            }
        }

        public static LoginScreenForm LoginScreenForm
        {
            get => default;
            set
            {
            }
        }

        public static SettingsForm SettingsForm
        {
            get => default;
            set
            {
            }
        }

        public static MainGame MainGame
        {
            get => default;
            set
            {
            }
        }
    }
}