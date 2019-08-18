using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelCheckInSystem.Models
{
    public class Role
    {
        #region Constructor
        public Role() : this(0, string.Empty, false)
        {
            //
        }

        public Role(int id, string description, bool isActive)
        {
            Id = id;
            Description = description;
            IsActive = isActive;
        }
        #endregion //Constructor


        #region Public Properties

        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// isActive
        /// </summary>
        public bool IsActive { get; set; }

        #endregion //Public Properties
    }
}
