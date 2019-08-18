using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HotelCheckInSystem.Models
{
    public class User
    {

        #region Constructor
        public User () : this(0, string.Empty, string.Empty, false, new Role())
        {
            //
        }

        public User (int id, string userName, string password, bool isActive, Role role)
        {
            Id = id;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Role = role;
        }
        #endregion //Constructor

        #region Public Properties

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// UserName
        /// </summary>
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// isActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public Role Role { get; set; }

        #endregion //Public Properties

    }
}
