namespace Aula02Delegates {
    internal class Program {
        static void Main(string[] args) {

            var room = new Room(3);
            room.RoomSoldOutEvent += OnRoomSoldOut;
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
        }
        static void OnRoomSoldOut(object sender, EventArgs e) {
            Console.WriteLine("Sala lotada!");
        }
    }
    
    public class Room {

        private int _seatsInUse;
        public int Seats { get; set; }
        public Room(int seats)
        {
            Seats = seats;
            _seatsInUse = 0;
        }

        public void ReserveSeat() {
            _seatsInUse++;
            if(_seatsInUse > Seats) {
                OnRoomSoldOut(EventArgs.Empty);
            }
            else {
                Console.WriteLine("Assento Reservado");
            }
        }

        public event EventHandler RoomSoldOutEvent;

        protected virtual void OnRoomSoldOut(EventArgs e) { 

            EventHandler handler = RoomSoldOutEvent;
            handler?.Invoke(this, e);
        }
    }
}
