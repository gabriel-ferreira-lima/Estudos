using JwtStore.Core.Contexts.AccountContext.ValueObjects;
using JwtStore.Core.Contexts.SharedContext.Extensions;
using JwtStore.Core.Contexts.SharedContext.ValueObjects;
using System.Text.RegularExpressions;

namespace JwtStore.Core.AccountContext.ValueObjects {
    public partial class Email : ValueObject {

        protected Email() { 
        }

        private const string Pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public Email(string address) {
            if (string.IsNullOrEmpty(address))
                throw new Exception("E-mail inválido");

            Address = address.Trim().ToLower();  
            
            if(Address.Length < 5) {
                throw new Exception("E-mail inválido");
            }

            if (!EmailRegex().IsMatch(Address)) {
                throw new Exception("E-mail inválido");
            }
        }

        public string Address { get; }

        public string Hash {
            get { return Address.ToBase64(); }
        }

        public Verification Verification { get; private set; } = new Verification();



        public void ResendVerification() {
            Verification = new Verification();
        }

        public static implicit operator string(Email email) {
            return email.ToString();
        }

        public static implicit operator Email(string address) {
            return new Email(address);
        }

        public override string ToString() {
            return Address;
        }

        [GeneratedRegex(Pattern)]
        private static partial Regex EmailRegex();
    }
}
