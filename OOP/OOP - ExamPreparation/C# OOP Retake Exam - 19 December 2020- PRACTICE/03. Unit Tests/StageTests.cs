// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   // using FestivalManager.Entities;
    using NUnit.Framework;
    using System;

    [TestFixture]
	public class StageTests
    {
        private Song song;
        private Song invalidTimeSong;
        private Performer performer;
        private Stage stage;
        private Performer invalidPerformer;

        [SetUp]
        public void SetUp()
        {
            this.song = new Song("opa", new TimeSpan(0, 1, 2));
            this.invalidTimeSong = new Song("opa", new TimeSpan(0, 0, 2));
            this.performer = new Performer("Pep", "Kos", 20);
            this.invalidPerformer = new Performer("Pep", "Kos", 10);
            this.stage = new Stage();
        }

		[Test]
	    public void AddPerformerCannotBeNull_ValidateTest()
	    {

            Assert.Throws<ArgumentNullException>(() => this.stage.AddPerformer(null));
		}

        [Test]
        public void AddPerformerSHouldThrowExceptionUnder18()
        {

            Assert.Throws<ArgumentException>(() => this.stage.AddPerformer(invalidPerformer));
        }

        [Test]
        public void AddPerformerSHouldWork()
        {
            this.stage.AddPerformer(performer);

            Assert.AreEqual(1, stage.Performers.Count);
        }

        [Test]
        public void AddSongCannotBeNull_ValidateTest()
        {

            Assert.Throws<ArgumentNullException>(() => this.stage.AddSong(null));
        }


        [Test]
        public void AddSongCannotBeUnder1Min()
        {

            Assert.Throws<ArgumentException>(() => this.stage.AddSong(invalidTimeSong));
        }

        //[Test]

        //public void AddSongWork()
        //{

        //    this.stage.AddSong(song);
        //    Assert.AreEqual(song, this.stage.ge);
        //}

        [Test]
        public void AddSongToPerformerValidateNullValueSongName()
        {
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(null, performer.FullName));
        }

        [Test]
        public void AddSongToPerformerValidateNullValuePerformerName()
        {
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
            Assert.Throws<ArgumentNullException>(() => this.stage.AddSongToPerformer(song.Name, null));
        }

        [Test]
        public void AddSongWork()
        {
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
           var result = this.stage.AddSongToPerformer(song.Name, performer.FullName);

            Assert.AreEqual(result, $"{song} will be performed by {performer}");
        }

        [Test]
        public void AddPlayWork()
        {
            this.stage.AddSong(song);
            this.stage.AddPerformer(performer);
            this.stage.AddSongToPerformer(song.Name, performer.FullName);

            var result = this.stage.Play();

            Assert.AreEqual(result, $"{1} performers played {1} songs");
        }




    }
}