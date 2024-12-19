

namespace Api.DTOs
{
    public record ATCCodeDto
    {
        public int Id { get; set; }
        public string? Code { get; set; }

        public static ATCCodeDto FromATCCode(Api.Models.ATCCodes atcCode)
        {
            return new ATCCodeDto
            {
                Id = atcCode.Id,
                Code = atcCode.Code
            };
        }
    }
}