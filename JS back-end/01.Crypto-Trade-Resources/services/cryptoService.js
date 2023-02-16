const Crypto = require("../models/Crypto");
const User = require("../models/User");

async function getAllCryptos() {
    return Crypto.find({}).lean();
}

async function createCrypto(crypto) {

    // const existingU = await Crypto.findOne({ name }).collation({ locale: 'en', strength: 2 });
    // if (existingU) {
    //     throw new Error('Crypto name is taken');
    // }

    return Crypto.create(crypto);
}

async function getById(id) {
    return Crypto.findById(id).lean();
}

async function deleteById(id) {
    return Crypto.findByIdAndDelete(id);
}

async function updateById(id, data, payment) {

    const existing = await Crypto.findById(id);

    existing.name = data.name;
    existing.image = data.image;
    existing.price = Number(data.price);
    existing.description = data.description;
    existing.payment = data.payment;

    return existing.save();
}

async function buy(cryptoId, userId) {
    const crypto = await Crypto.findById(cryptoId);
    if (crypto.buyCryptoUsers.includes(userId)) {
        throw new Error('Cannot buy twice')
    }

    crypto.buyCryptoUsers.push(userId);
    //crypto.freeRooms -= 1;

    //bookU(cryptoId, userId);

    return crypto.save();
}

async function bookU(cryptoId, userId) {

    const existingU = await User.findById(userId);

    existingU.booked.push(cryptoId);

    existingU.save();
}

async function getBookingsByUser(userId) {
    return Crypto.find({ usersBooked: userId }).lean();
}

//---SEARCH
async function search(searchName, searchPayment) {
    let query = {};
  
    if (searchName) {

        query.name = new RegExp(searchName, 'i');
       
       
    }
    if (searchPayment) {

      
        query.payment = new RegExp(searchPayment, 'i');
        
    }


    return Crypto.find(query).lean();

   
}

module.exports = {
    search,
    createCrypto,
    getById,
    deleteById,
    updateById,
    buy,
    getAllCryptos,
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

