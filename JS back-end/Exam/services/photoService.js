const Photo = require("../models/Photo");
const User = require("../models/User");

async function getAllPhotos() {
    return Photo.find({}).lean();
}

async function getAllPhotosByUserId(userId) {
    const collection = [];
    const photos = await Photo.find({});
    const ownPhotos = photos.forEach(x => {
        if(x.owner == userId) {
            collection.push(x)
        }
    })


    return collection;
}

async function createPhoto(photo) {

    //const existingU = await Photo.findOne({ name }).collation({ locale: 'en', strength: 2 });
    // if (existingU) {
    //     throw new Error('Photo name is taken');
    // }

    return Photo.create(photo);
}

async function getById(id) {
    return Photo.findById(id).lean();
}

async function deleteById(id) {
    return Photo.findByIdAndDelete(id);
}

async function updateById(id, data) {

    const existing = await Photo.findById(id);

    existing.name = data.name;
    existing.age = Number(data.age);
    existing.image = data.image;
    existing.description = data.description;
    existing.location = data.location;
    existing.owner = data.owner;


    return existing.save();
}

async function comment(username, comment, userId, photoId) {
    const photo = await Photo.findById(photoId);
    const user = await User.findById(userId);
    // if (photo.usersBooked.includes(userId)) {
    //     throw new Error('Cannot comment twice')
    // }
username = user.username
    photo.commentList.push({userId, username, comment });
 

    return photo.save();
}

async function bookU(PhotoId, userId) {

    const existingU = await User.findById(userId);

    existingU.booked.push(PhotoId);

    existingU.save();
}

async function getBookingsByUser(userId) {
    return Photo.find({ usersBooked: userId }).lean();
}

module.exports = {
    getAllPhotosByUserId,
    createPhoto,
    getById,
    deleteById,
    updateById,
    comment,
    getAllPhotos,
    getBookingsByUser
}

// async function getRecent() {
//     return Course.find({}).sort({ userCount: -1 }).limit(3).lean();
// }

// async function getAllByDate(search) {
//     let query = {};
//     if (search) {

//         query.title = new RegExp(search, 'i');
//     }

//     return Course.find(query).sort({ createdAt: 1 }).lean();
// }

