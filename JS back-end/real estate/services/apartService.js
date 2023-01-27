const Apart = require("../models/Apart");
const User = require("../models/User");

async function getAllAparts() {
    return Apart.find({}).lean();
}

async function getLimitedAparts() {
    return Apart.find({}).limit(3).lean();
}

async function createApart(apart) {

    // const existingU = await Apart.findOne({ name }).collation({ locale: 'en', strength: 2 });
    // if (existingU) {
    //     throw new Error('Apart name is taken');
    // }

    return Apart.create(apart);
}

async function getById(id) {
    return Apart.findById(id).lean();
}

async function deleteById(id) {
    return Apart.findByIdAndDelete(id);
}

async function updateById(id, data) {

    const existing = await Apart.findById(id);

    existing.name = data.name;
    existing.type = data.type;
    existing.year = data.year;
    existing.city = data.city;
    existing.image = data.image;
    existing.description = data.description;
    existing.available = Number(data.available);

    return existing.save();
}

async function rent(apartId, userId, name) {

    const apart = await Apart.findById(apartId);

    if (apart.rented.includes(name)) {

        throw new Error('Cannot rent twice')
    }

    if (apart.rented.length > 0) {
        apart.rented[apart.rented.length - 1] = apart.rented[apart.rented.length - 1] + ','
    }
    apart.rented.push(name);

    apart.available -= 1;

    return apart.save();
}

async function bookH(apartId, userId) {
    const apart = await Apart.findById(apartId);
    if (apart.usersBooked.includes(userId)) {
        throw new Error('Cannot book twice')
    }

    apart.usersBooked.push(userId);
    apart.freeRooms -= 1;

    bookU(apartId, userId);

    return apart.save();
}

async function bookU(apartId, userId) {

    const existingU = await User.findById(userId);

    existingU.booked.push(apartId);

    existingU.save();
}

async function getBookingsByUser(userId) {
    return Apart.find({ usersBooked: userId }).lean();
}

async function getRentalsByUser(id) {

    const apart = Apart.findById(id).lean();

    return apart.rented;
}

async function search(search) {
    let query = {};
    if (search) {

        query.type = new RegExp(search, 'i');
    }

    return Apart.find(query).lean();
}

module.exports = {
    createApart,
    getById,
    deleteById,
    updateById,
    bookH,
    getAllAparts,
    getBookingsByUser,
    getLimitedAparts,
    rent,
    getRentalsByUser,
    search
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

