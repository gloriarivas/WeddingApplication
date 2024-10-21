using WeddingAppDatabase.Entities;
namespace WeddingApp.Models
{
	public class GuestListViewModel
	{
		public List<Guests> Guests { get; set; }

		public List<WeddingParty>? WeddingParty { get; set; }

		public List<PlusOnes>? PlusOnes { get; set; }
	}
}