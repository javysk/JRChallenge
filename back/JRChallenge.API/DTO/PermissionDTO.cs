namespace JRChallenge.API.DTO
{
    public class PermissionDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }
        public DateTime PermissionDate { get; set; }
        public long PermissionTypeId { get; set; }
    }
}
