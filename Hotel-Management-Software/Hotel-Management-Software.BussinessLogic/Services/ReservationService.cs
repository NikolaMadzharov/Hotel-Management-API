using AutoMapper;
using Hotel_Management_Software.BBL.Services.IServices;
using Hotel_Management_Software.DAL.Entities;
using Hotel_Management_Software.DAL.Repositories.IRepositories;
using Hotel_Management_Software.DTO.Reservation;

namespace Hotel_Management_Software.BBL.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IGuestRepository _guestRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ReservationService(
            IReservationRepository reservationRepository, 
            IGuestRepository guestRepository, 
            IMapper mapper,
            IEmailService emailService)
        {
            _reservationRepository = reservationRepository;
            _guestRepository = guestRepository;
            _mapper = mapper;
            _emailService = emailService;
        }

        public async Task<Guid> BookAsync(AddReservationDTO addReservationDTO)
        {
            var guestDTO =  _mapper.Map<Guest>(addReservationDTO);

            if (guestDTO == null) 
            {
                throw new ArgumentNullException(nameof(guestDTO));
            }

         var guest =  await _guestRepository.AddAsync(guestDTO);

            var reservationDTO = _mapper.Map<Reservation>(addReservationDTO);

                reservationDTO.GuestId = guest.Id;

         var reservation =  await  _reservationRepository.AddAsync(reservationDTO);

            if (reservation is not null)
            {
                await _emailService.SendEmailForBookedReservation(reservationDTO);
                return reservation.Id;
            }

    

            return Guid.Empty;
        }

        public async Task<List<ReservationDTO>> GetAllReservationsByRoomAsync(Guid id)
        {
            var reservation = await _reservationRepository.GetListAsync(x => x.RoomId == id);

            var reservationDTO = _mapper.Map<List<ReservationDTO>>(reservation);

            return reservationDTO;
        }

        public  async Task<List<CalendarReservationDTO>> GetCalendarBookedDayAsync(Guid roomId)
        {
            var reservations =  await _reservationRepository.GetListAsync(x => x.RoomId == roomId);

            var reservationsDTO = _mapper.Map<List<CalendarReservationDTO>>(reservations);

            if (reservationsDTO is not null)
            {
                return reservationsDTO;
            }

            return null;
        }

        public async Task<ReservationDTO> GetReservationAsync(Guid reservationId)
        {
            var reservation = await _reservationRepository.GetAsync(x => x.Id == reservationId);

            var reservationDTO = _mapper.Map<ReservationDTO>(reservation);

            return reservationDTO;
        }
    }
}
