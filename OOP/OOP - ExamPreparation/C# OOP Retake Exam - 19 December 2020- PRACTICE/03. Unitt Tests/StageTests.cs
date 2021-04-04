// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
    using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
   
    using System.Linq;
   

    [TestFixture]
	public class StageTests
    {
		private Stage stage;
		private Song song;
		private Performer performer;
		[SetUp]
		public void InIt()
		{
			this.stage = new Stage();
			this.song = new Song("Techno", new TimeSpan(0, 5, 59));
			this.performer = new Performer("Pesho", "Peshev", 25);
		}
		[Test]
		public void TestConstructor()
		{
			Assert.IsNotNull(stage);
		}

		[Test]
		public void TestIReadOnly()
		{
			Assert.IsNotNull(stage.Performers);
		}

		[Test]
	    public void testAddPerformer_ShouldThrowException_WhenUnder18()
	    {
			Stage stage = new Stage();
			Performer performer = new Performer("Pesho", "Peshev", 12);

			Assert.Throws<ArgumentException>(() => { stage.AddPerformer(performer); });
		}

		[Test]
		public void testAddPerformer_ShouldThrowException_WhenFirstNameIsNull()
		{
			Stage stage = new Stage();
			Performer performer = new Performer(null, "Peshev", 12);

			Assert.Throws<ArgumentException>(() => { stage.AddPerformer(performer); });
		}

		[Test]
		public void testAddPerformer_ShouldThrowException_WhenSecondNameIsNull()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Pesho", null, 12);

			Assert.Throws<ArgumentException>(() => { stage.AddPerformer(performer); });
		}


		[Test]
		public void testAddPerformer_ShouldThrowException_WhenPerformerIsNull()
		{
			Stage stage = new Stage();
			Performer performer = null;

			Assert.Throws<ArgumentNullException>(() => { stage.AddPerformer(performer); });
		}

		[Test]
		public void testAddPerformer_ShouldWork()
		{
			Stage stage = new Stage();
			Performer performer = new Performer("Pesho", "Peshev", 25);

			 stage.AddPerformer(performer);
			Assert.AreEqual(1, stage.Performers.Count);
		}
		[Test]
		public void testAddSong_ShouldThrowException_WhenLessThan1Min()
		{
			Stage stage = new Stage();

			Song song = new Song("Techno", new TimeSpan(0,0,59));

			Assert.Throws<ArgumentException>(() => { stage.AddSong(song); });
		}

		[Test]
		public void testAddSong_ShouldWork()
		{
			Stage stage = new Stage();

			Performer performer = new Performer("Pesho", "Peshev", 25);

			Song song = new Song("Techno", new TimeSpan(2, 0, 59));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer(song.Name, performer.FullName);

			Assert.AreEqual(1, performer.SongList.Count);
		}
		[Test]
		public void testAddSong_ShouldThrowExceptionWhenNull()
		{
			Stage stage = new Stage();

			Performer performer = new Performer("Pesho", "Peshev", 25);

			Song song = new Song("op sa", new TimeSpan(1, 2, 2));
			stage.AddPerformer(performer);
		

			Assert.Throws<ArgumentNullException>(() => { stage.AddSongToPerformer(null, performer.FullName); });

			
		}

		[Test]
		public void testAddSong_ShouldThrowExceptionWhenSongIsNull()
		{
			Stage stage = new Stage();
			
			Song song = null;
			
			
	
			Assert.Throws<ArgumentNullException>(() => { stage.AddSong(song); });
		}

		[Test]
		public void testPlay_ShouldWork()
		{
			Stage stage = new Stage();

			Performer performer = new Performer("Pesho", "Peshev", 25);

			Song song = new Song("Techno", new TimeSpan(2, 0, 59));
			stage.AddPerformer(performer);
			stage.AddSong(song);

			stage.AddSongToPerformer(song.Name, performer.FullName);

			string returnedResult = stage.Play();

			Assert.AreEqual(returnedResult, $"{stage.Performers.Count} performers played {performer.SongList.Count} songs");
		}
		[Test]
		public void GetPerformerShouldThrowException()
		{
			string wrongName = "wrong name";
			this.song = new Song("Budata", new TimeSpan(0, 1, 0));
			this.stage.AddSong(this.song);
			this.stage.AddPerformer(this.performer);
			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
			Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(this.song.Name, wrongName));
		}

		[Test]
		public void GetSongShouldThrowException()
		{
			string wrongName = "wrong name";
			this.song = new Song("Budata", new TimeSpan(0, 1, 0));
			this.stage.AddSong(this.song);
			this.stage.AddPerformer(this.performer);
			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
			Assert.Throws<ArgumentException>(() => this.stage.AddSongToPerformer(wrongName, this.performer.FullName));
		}
		[Test]
		public void PlayShouldReturnCorrectString()
		{
			Song songOne = new Song("One", new TimeSpan(0, 1, 0));
			Song songTwo = new Song("Two", new TimeSpan(0, 1, 0));
			this.stage.AddSong(songOne);
			this.stage.AddSong(songTwo);
			this.stage.AddPerformer(this.performer);
			this.stage.AddSongToPerformer(songOne.Name, this.performer.FullName);
			this.stage.AddSongToPerformer(songTwo.Name, this.performer.FullName);
			Assert.AreEqual("1 performers played 2 songs", this.stage.Play());
		}
		[Test]
		public void AddingSongToPerformerSouldReturnCorrectCount()
		{
			int expectedCount = 1;
			this.song = new Song("Budata", new TimeSpan(0, 1, 0));
			this.stage.AddSong(this.song);
			this.stage.AddPerformer(this.performer);
			this.stage.AddSongToPerformer(this.song.Name, this.performer.FullName);
			Assert.AreEqual(expectedCount, this.performer.SongList.Count);
		}
	}
}