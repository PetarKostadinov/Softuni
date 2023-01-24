const Hotel = require("../models/Hotel");
const User = require("../models/User");

async function getAllHotels() {
    return Hotel.find({}).lean();
}

async function createHotel(hotel, name) {

    const existingU = await Hotel.findOne({ name }).collation({ locale: 'en', strength: 2 });
    if (existingU) {
        throw new Error('Hotel name is taken');
    }

    return Hotel.create(hotel);
}

async function getById(id) {
    return Hotel.findById(id).lean();
}

async function deleteById(id) {
    return Hotel.findByIdAndDelete(id);
}

async function updateById(id, data) {

    const existing = await Hotel.findById(id);

    existing.name = data.name;
    existing.city = data.city;
    existing.freeRooms = Number(data.freeRooms);
    existing.image = data.image;

    return existing.save();
}

async function bookH(hotelId, userId) {
    const hotel = await Hotel.findById(hotelId);
    if (hotel.usersBooked.includes(userId)) {
        throw new Error('Cannot book twice')
    }

    hotel.usersBooked.push(userId);
    hotel.freeRooms -= 1;

    bookU(hotelId, userId);

    return hotel.save();
}

async function bookU(hotelId, userId) {

    const existingU = await User.findById(userId);

    existingU.booked.push(hotelId);

    existingU.save();
}

async function getBookingsByUser(userId) {
    return Hotel.find({ usersBooked: userId }).lean();
}

module.exports = {
    createHotel,
    getById,
    deleteById,
    updateById,
    bookH,
    getAllHotels,
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

