// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   // using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
   
    using System.Linq;
   

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Song validSong;
		private Song invalidSong;
		private Song nullSong;
		private Performer invalidPerformer;
		private Performer validPerformer;
		private Performer nullPerformer;
		[SetUp]
		public void InIt()
		{
			this.stage = new Stage();
			 this.validPerformer = new Performer("Pesho", "Peshev", 20);
			this.invalidPerformer = new Performer("Pesho", "Peshev", 10);
			this.validSong = new Song("lala", new TimeSpan(0, 5, 25));
			this.invalidSong = new Song("lala", new TimeSpan(0, 0, 25));
			this.nullSong = null;
			this.nullPerformer = null;
		}
		
		[Test]
	    public void testAddPerformer_ShouldThrowException_WhenUnder18()
	    {
			Assert.Throws<ArgumentException>(() => { this.stage.AddPerformer(this.invalidPerformer); });
		}

		[Test]
		public void testAddPerformer_ShouldThrowException_WhenPerformerIsIsNull()
		{

			Assert.Throws<ArgumentNullException>(() => { this.stage.AddPerformer(this.nullPerformer); });
		}

		[Test]
		public void testAddPerformer_ShouldWork()
		{
			this.stage.AddPerformer(this.validPerformer);

			Assert.AreEqual(1, this.stage.Performers.Count);
		}


		[Test]
		public void testAddSong_ShouldThrowException_WhenUnder1Min()
		{
			Assert.Throws<ArgumentException>(() => { this.stage.AddSong(this.invalidSong); });
		}

		[Test]
		public void testAddSong_ShouldThrowException_WhenSongIsIsNull()
		{

			Assert.Throws<ArgumentNullException>(() => { this.stage.AddSong(this.nullSong); });
		}

		[Test]
		public void testAddSongToPerfomer_ShouldThrowException_WhenSongNameIsIsNull()
		{
			var nullNameSong = new Song(null, new TimeSpan(1, 2, 3));

			Assert.Throws<ArgumentNullException>(() => { this.stage.AddSongToPerformer(nullNameSong.Name, this.validPerformer.FullName); });
		}

		[Test]
		public void testAddSongToPerfomer_ShouldWork()
		{
			this.stage.AddSong(this.validSong);
			this.stage.AddPerformer(this.validPerformer);
			this.stage.AddSongToPerformer(this.validSong.Name, this.validPerformer.FullName);

			Assert.AreEqual(1, this.validPerformer.SongList.Count);
		}

		[Test]
		public void testAddSongToPerfomer_ShoulReturnCorect()
		{
			this.stage.AddSong(this.validSong);
			this.stage.AddPerformer(this.validPerformer);
		
			var expected = $"{validSong} will be performed by {validPerformer}";
			var actual = this.stage.AddSongToPerformer(this.validSong.Name, this.validPerformer.FullName);

			Assert.AreEqual(actual, expected);
		}
		[Test]
		public void testPlay_ShouldWork()
		{
			this.stage.AddSong(this.validSong);
			this.stage.AddPerformer(this.validPerformer);
			this.stage.AddSongToPerformer(this.validSong.Name, this.validPerformer.FullName);
			var songsCount = this.stage.Performers.Sum(p => p.SongList.Count());
			var result = $"{this.stage.Performers.Count} performers played {songsCount} songs";

			var actual = stage.Play();
			Assert.AreEqual(actual, result);
			Assert.AreEqual(1, songsCount);
		}

	}
}