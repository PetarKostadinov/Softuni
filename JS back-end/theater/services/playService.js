
const { hasUser } = require('../middlewares/guards');
const Play = require('../models/Play');

async function createPlay(play) {

    const patern = new RegExp(`^${play.name}$`, 'i');
    const existing = await Play.findOne({ name: { $regex: patern } });

    if (existing) {
        throw new Error('A play with this name already exists')
    }

    const result = new Play(play);
    await result.save();

    return result;
}

async function getAllPlays(orderBy) {

    let sort = { created: -1 };
    if (orderBy == 'likes') {
        sort = { usersLiked: 'desc' }
    }
    return Play.find({ isPublic: true }).sort(sort).lean();
}

async function getRecent() {
    return Play.find({}).sort({ usersLiked: -1 }).limit(3).lean();
}

async function getPlayById(id) {
    return Play.findById(id).populate('usersLiked').lean();
}

async function updatePlay(id, play) {
    const existing = await Play.findById(id);

    existing.name = play.name;
    existing.description = play.description;
    existing.image = play.image;
    existing.isPublic = Boolean(play.isPublic);

    await existing.save();
}

async function deletePlay(id) {
    await Play.findByIdAndRemove(id);
}

async function vote(playId, userId) {
    const play = await Play.findById(playId);

    if (play.usersLiked.includes(userId)) {
        play.isLiked = true;
        throw new Error('User has already voted');
    }

    play.usersLiked.push(userId);
    play.count += 1;

    await play.save();
}

module.exports = {
    createPlay,
    getAllPlays,
    getPlayById,
    updatePlay,
    deletePlay,
    vote,
    getRecent
}