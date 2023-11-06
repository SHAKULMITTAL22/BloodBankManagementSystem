public class DonorRepository
{
    private readonly string _connectionString;

    public DonorRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable Search(string keywords)
    {
        var dt = new DataTable();

        using (var conn = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM tbl_donors WHERE donor_id LIKE @keywords OR first_name LIKE @keywords OR last_name LIKE @keywords OR email LIKE @keywords OR blood_group LIKE @keywords";

            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@keywords", "%" + keywords + "%");

                var adapter = new SqlDataAdapter(cmd);

                conn.Open();

                adapter.Fill(dt);
            }
        }

        return dt;
    }
}
