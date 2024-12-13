using System.Data;
using System.Data.SqlClient;
using TrainingDay4.Model;

namespace TrainingDay4.Repository
{
    public class SlabsRepo : ISlabsRepo
    {
        private readonly string _Connectionstring;
        public SlabsRepo(string connectionstring)
        {
            _Connectionstring = connectionstring;
        }

        public List<Slabs>GetSlabs (int versionid) 
        {
            List<Slabs> slabs = new List<Slabs>();

            using (SqlConnection connection = new SqlConnection(_Connectionstring))
            {
                using (SqlCommand command = new SqlCommand("spGetSLABS", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IBSVerId", versionid);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Slabs slab = new Slabs();

                            slab.Id = reader.GetByte("SLA_ID");
                            slab.Name = reader.GetString("SLA_NAME");
                            slab.DisplayOrder = reader.GetByte("SLA_DISPLAYORDER");
                            
                            slabs.Add(slab);
                        }
                    }
                }
            }

            return slabs;
        }

    }
}
