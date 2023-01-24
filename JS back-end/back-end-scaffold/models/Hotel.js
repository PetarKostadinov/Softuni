
const { Schema, model, Types } = require('mongoose');

const URL_PATERN = /http(s)?:\/\/./i;

const hotelSchema = new Schema({

    name: { type: String, minlength: [4, 'Hotel name must be at least 4 characters long'] },
    city: { type: String, minlength: [3, 'City must be at least 3 characters long'] },
    freeRooms: {
        type: Number, required: true,
        min: [1, 'Minimum free rooms required 1'],
        max: [100, 'Maximum free rooms required 100'],
        default: 0
    },
    image: {
        type: String, validate: {
            validator: (value) => URL_PATERN.test(value),
            message: 'Invalid URL'
        }
    },
    usersBooked: { type: [Types.ObjectId], ref: 'User', default: [] },
    owner: { type: Types.ObjectId, ref: 'User', required: true }
});

hotelSchema.index({ name: 1 }, {
    collation: {
        locale: 'en',
        strength: 2
    }
})

const Hotel = model('Hotel', hotelSchema);

module.exports = Hotel;


 //     title: { type: String, minlength: [4, 'Course title must be at least 4 characters long'] },
    //     description: {
    //         type: String,
    //         minlength: [20, 'Description must be at least 20 characters long'],
    //         maxlength: [50, 'Description must be at maimum 50 characters long']
    //     },
    //     imageUrl: {
    //         type: String, validate: {
    //             validator: (value) => URL_PATERN.test(value),
    //             message: 'Invalid URL'
    //         }
    //     },
    //     duration: { type: String, required: [true, 'Duration is required'] },
    //     createdAt: { type: String, required: true, default: () => (new Date()).toISOString().slice(0, 10) },
    //     users: { type: [Types.ObjectId], ref: 'User', default: [] },
    //     userCount: { type: Number, default: 0 },
    //     owner: { type: Types.ObjectId, ref: 'User' }