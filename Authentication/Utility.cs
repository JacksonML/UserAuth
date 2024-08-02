using System.Security.Cryptography;

namespace AsyncCoder.UserAuth.Authentication
{
    internal static class Utility
    {

        private const int _saltSize = 16; // 128 bits
        private const int _keySize = 64; // 512 bits
        private const int _iterations = 50000;
        private static readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA256;
        private const char segmentDelimiter = ':';

        public static byte[] CreateSalt()
        {
            var salt = RandomNumberGenerator.GetBytes(_saltSize);
            return salt;
        }

        /// <summary>
        /// Hashes the provided string
        /// </summary>
        public static string Hash(string value)
        {
            var salt = CreateSalt();
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                        value,
                        salt,
                        _iterations,
                        _algorithm,
                        _keySize
                    );
            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                _iterations,
                _algorithm
            );
        }

        /// <summary>
        /// Verifies a password matches the given hash
        /// </summary>
        public static bool Verify(string password, string hashString)
        {
            string[] segments = hashString.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);
            byte[] inputHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                algorithm,
                hash.Length
            );
            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }
    }
}