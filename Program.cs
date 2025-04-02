using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using ReaLTaiizor.Controls;
using SpiceSharp;
using SpiceSharp.Components;
using System.Data.SQLite;
using System.Data;
using SpiceSharp.Simulations;
using static LockedAspectRatioForm;
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
        public static System.Windows.Forms.FormBorderStyle originalBorderStyle;
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
            Application.Run(new MainGame());
        }

        public static void ApplyTransparentUI(ref PictureBox pbox, ref Label label)
        {
            System.Drawing.Point labelPos = label.Location;
            pbox.Controls.Add(label);
            label.Location = labelPos;
            label.BackColor = Color.Transparent;
        }
        public static void ApplyTransparentUI(ref PictureBox pbox, ref TextBox tbx)
        {
            System.Drawing.Point labelPos = tbx.Location;
            pbox.Controls.Add(tbx);
            tbx.Location = labelPos;
        }
        public static void ApplyTransparentUI(ref PictureBox pbox, ref ParrotSlider sldr)
        {
            System.Drawing.Point labelPos = sldr.Location;
            pbox.Controls.Add(sldr);
            sldr.Location = labelPos;
        }
        public static void ApplyTransparentUIVideo(ref VideoView media, ref MaterialSkin.Controls.MaterialButton bttn)
        {
            System.Drawing.Point labelPos = bttn.Location;
            media.Controls.Add(bttn);
            media.Location = labelPos;
        }
    }

    public static class DataClass
    {
        private static string databaseName = "Database.db"; // Name of your SQLite database file
        private static string connectionString = $"Data Source={databaseName};Version=3;";
        public static string username;
        public static byte[] profileImageBytes;
        public static int circuitsCompleted;
        public static int burnedResistors;
        public static int burnedLed;
        public static int rating;

        public static int musicVolume;
        public static int soundVolume;

        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2")); // Convert byte to hex string
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword.Equals(storedHash, StringComparison.OrdinalIgnoreCase); // Case-insensitive comparison
        }

        public static void ConnectionDatabase()
        {
            string databaseName = "Database.db";
            string connectionString = $"Data Source={databaseName};Version=3;"; // Connection string
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string createTableSql = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Username TEXT PRIMARY KEY NOT NULL UNIQUE,
                        PasswordHash TEXT NOT NULL,
                        ProfileImage BLOB,
                        CircuitsCompleted INTEGER NOT NULL DEFAULT 0,
                        BurnedResistors INTEGER NOT NULL DEFAULT 0,
                        BurnedLed INTEGER NOT NULL DEFAULT 0,
                        Rating INTEGER NOT NULL DEFAULT 0,
                        MusicVolume INTEGER NOT NULL DEFAULT 100,
                        SoundVolume INTEGER NOT NULL DEFAULT 100
                    );";

                    using (SQLiteCommand createTableCommand = new SQLiteCommand(createTableSql, connection))
                    {
                        createTableCommand.ExecuteNonQuery();
                        //MessageBox.Show("Table 'Users' created (or already exists) with updated schema.");
                    }
                } 
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Error connecting to SQLite database: {ex.Message}");
            }
        }

        public static void RegisterUser(string username, string passwordText)
        {
            string databaseName = "Database.db"; // Name of your SQLite database file
            string connectionString = $"Data Source={databaseName};Version=3;"; // Connection string

            string passwordHash = HashPassword(passwordText); // Hash the password
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string insertUserSql = @"
                    INSERT INTO Users (Username, PasswordHash, ProfileImage)
                    VALUES (@Username, @PasswordHash, @ProfileImage);";

                    using (SQLiteCommand insertUserCommand = new SQLiteCommand(insertUserSql, connection))
                    {
                        insertUserCommand.Parameters.AddWithValue("@Username", username);
                        insertUserCommand.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        insertUserCommand.Parameters.AddWithValue("@ProfileImage", null);
                        insertUserCommand.ExecuteNonQuery();
                        //MessageBox.Show($"User '{username}' registered successfully.");
                    }
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show($"Error inserting user into SQLite database: {ex.Message}");
            }
        }

        public static bool AuthenticateUser(string username, string passwordText)
        {
            string databaseName = "Database.db"; // Name of your SQLite database file
            string connectionString = $"Data Source={databaseName};Version=3;"; // Connection string

            string passwordHash = HashPassword(passwordText); // Hash the password
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string selectUserSql = @"
                    SELECT PasswordHash
                    FROM Users
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
            string databaseName = "Database.db"; // Name of your SQLite database file
            string selectUserDataSql = "SELECT * FROM Users WHERE Username = @Username;"; // Select all columns
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
                            username = reader.GetString(0); // Username (index 0)
                                                            // Note: We *don't* retrieve the PasswordHash for security reasons in a real application
                            profileImageBytes = reader["ProfileImage"] as byte[]; // Get BLOB data
                            circuitsCompleted = reader.GetInt32(3); // CircuitsCompleted (index 3)
                            burnedResistors = reader.GetInt32(4); // BurnedResistors (index 4)
                            burnedLed = reader.GetInt32(5);    // BurnedLed (index 5)
                            rating = reader.GetInt32(6);   // Rating (index 6)
                            musicVolume = reader.GetInt32(7);   // MusicVolume (index 7)
                            soundVolume = reader.GetInt32(8);   // SoundVolume (index 8)


                            //if (profileImageBytes != null && profileImageBytes.Length > 0)
                            //{
                            //    string savedImagePath = "retrieved_profile_image.png"; // Or .jpg, determine type if needed
                            //    File.WriteAllBytes(savedImagePath, profileImageBytes);
                            //    Console.WriteLine($"Profile image saved to '{savedImagePath}'.");
                            //}
                            //else
                            //{
                            //    Console.WriteLine("No profile image found for this user.");
                            //}
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

        public static bool UpdateUserField(SQLiteConnection connection, string usernameToUpdate, string fieldToUpdate, object newValue)
        {
            if (connection == null || connection.State != System.Data.ConnectionState.Open)
            {
                //MessageBox.Show("Error: Database connection is not open or valid.");
                return false;
            }

            string updateSql = "";
            switch (fieldToUpdate.ToLower())
            {
                case "username":
                    updateSql = "UPDATE Users SET Username = @NewValue WHERE Username = @Username;";
                    break;
                case "password":
                    updateSql = "UPDATE Users SET PasswordHash = @NewValue WHERE Username = @Username;";
                    break;
                case "profileimage":
                    updateSql = "UPDATE Users SET ProfileImage = @NewValue WHERE Username = @Username;";
                    break;
                case "circuitscompleted":
                    updateSql = "UPDATE Users SET CircuitsCompleted = @NewValue WHERE Username = @Username;";
                    break;
                case "burnedresistors":
                    updateSql = "UPDATE Users SET BurnedResistors = @NewValue WHERE Username = @Username;";
                    break;
                case "burnedled":
                    updateSql = "UPDATE Users SET BurnedLed = @NewValue WHERE Username = @Username;";
                    break;
                case "rating":
                    updateSql = "UPDATE Users SET Rating = @NewValue WHERE Username = @Username;";
                    break;
                case "musicvolume":
                    updateSql = "UPDATE Users SET MusicVolume = @NewValue WHERE Username = @Username;";
                    break;
                case "soundvolume":
                    updateSql = "UPDATE Users SET SoundVolume = @NewValue WHERE Username = @Username;";
                    break;
                default:
                    MessageBox.Show($"Error: Field '{fieldToUpdate}' is not a valid field to update.");
                    return false;
            }

            if (string.IsNullOrEmpty(updateSql))
            {
                return false;
            }

            using (SQLiteCommand updateCommand = new SQLiteCommand(updateSql, connection))
            {
                if (fieldToUpdate.ToLower() == "password")
                {
                    newValue = HashPassword(newValue as string);
                }
                updateCommand.Parameters.AddWithValue("@NewValue", newValue);
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

                    string deleteUserSql = "DELETE FROM Users WHERE Username = @Username;";
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
                SELECT Username, ProfileImage, PasswordHash, CircuitsCompleted, BurnedResistors, BurnedLed, Rating, MusicVolume, SoundVolume
                FROM Users
                ORDER BY Rating DESC;";
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
                                return sortedUsers; // Exit the method
                            }

                            while (reader.Read())
                            {
                                TempUserInformation tempUserInformation = new TempUserInformation();
                                tempUserInformation.Username = reader.GetString(0);
                                tempUserInformation.ProfileImage = reader["ProfileImage"] as byte[];
                                tempUserInformation.CircuitsCompleted = reader.GetInt32(3);
                                tempUserInformation.BurnedResistors = reader.GetInt32(4);
                                tempUserInformation.BurnedLed = reader.GetInt32(5);
                                tempUserInformation.Rating = reader.GetInt32(6);
                                sortedUsers.Add(tempUserInformation);
                            }
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show($"Error selecting sorted users from SQLite database: {ex.Message}");
            }
            return sortedUsers;
        }

        public static void ResetUser()
        {
            UpdateUserInformation("CircuitsCompleted", 0);
            UpdateUserInformation("BurnedResistors", 0);
            UpdateUserInformation("BurnedLed", 0);
            UpdateUserInformation("Rating", 0);
        }
    }


    internal static class  ResourceHelper
    {
        public static Image LoadVideoFromResource(string imageName)
        {
            try
            {
                string exePath = Path.Combine(Application.StartupPath, "Images", "CircuitElements", imageName);
                if (File.Exists(exePath))
                {
                    return Image.FromFile(exePath);
                }
                string projectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Resources\CircuitElements", imageName);
                if (File.Exists(projectPath))
                {
                    return Image.FromFile(projectPath);
                }
                throw new FileNotFoundException($"Image file not found: {imageName}.  Checked:\n{exePath}\n{projectPath}");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show($"Image file not found: {imageName}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}