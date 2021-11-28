using CancunHotel.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CancunHotel.Application.ViewModels
{
    public class BookingVM
    {
        public Guid Id { get; set; }

        public Guid RoomId { get; set; }
        public string RoomName { get => "Room number: " + Room?.Number + "| " + Room?.Description; }

        public RoomVM Room { get; set; }

        public Guid CustomerId { get; set; }

        public ProfileVM Customer { get; set; }

        public DateTime CheckIn { get; set; }

        public DateTime CheckOut { get; set; }

        public bool Cancelled { get; set; }

    }
}
