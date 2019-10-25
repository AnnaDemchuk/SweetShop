using Step.Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.DbLayer
{
    public partial class SubCategory : Entity<int>
    {

        [NotMapped]
        public override int Id
        {
            get
            {
                return SubCategoryId;
            }
            set
            {
                SubCategoryId = value;
            }
        }
    }
}

