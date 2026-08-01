using Flunt.Notifications;

namespace JwtStore.Core.Contexts.SharedContext.UseCases {
    public abstract class Response {
        public string Message { get; set; } = string.Empty;
        public int Status { get; set; } = 400;
        public bool IsSuccess {
            get {
                if (Status >= 200 && Status <= 299) {
                    return true;
                }

                return false;
            }
        }
        public IEnumerable<Notification>? Notifications { get; set; }
    }
}
