
const { Schema, model, Types } = require('mongoose');

const URL_PATERN = /http(s)?:\/\/./i;

const apartSchema = new Schema({

    name: { type: String, minlength: [6, 'Name must be at least 6 characters long'] },
    type: {
        type: String,
        enum: ['Apartment', 'Villa', 'House'],
        required: [true, 'Plese enter \'Apartment\', \'Villa\' or \'House\'']
    },
    year: {
        type: Number,
        min: [1850, 'Year must be between 1850 and 2021'],
        max: [2021, 'Year must be between 1850 and 2021']
    },
    city: {
        type: String,
        minlength: [4, 'City name must be at least 4 characters long']
    },
    image: {
        type: String,
        validate: {
            validator: (value) => URL_PATERN.test(value),
            message: 'The Home Image should starts with http:// or https://'
        }
    },
    description: {
        type: String,
        required: [true, 'Description is required'],
        maxlength: [60, 'The description must be maximum 60 characters long']
    },
    available: {
        type: Number,
        min: [0, 'The Available Pieces should be positive number (from 0 to 10)'],
        max: [10, 'The Available Pieces should be positive number (from 0 to 10)']
    },
    rented: { type: Array, ref: 'User', default: [] },
    owner: { type: Types.ObjectId, ref: 'User'}


    //     name: { type: String, minlength: [4, 'Apart name must be at least 4 characters long'] },
    //     city: { type: String, minlength: [3, 'City must be at least 3 characters long'] },
    //     freeRooms: {
    //     type: Number, required: true,
    //     min: [1, 'Minimum free rooms required 1'],
    //     max: [100, 'Maximum free rooms required 100'],
    //     default: 0
    // },
    //     image: {
    //     type: String, validate: {
    //         validator: (value) => URL_PATERN.test(value),
    //         message: 'Invalid URL'
    //     }
    // },
    //     usersBooked: { type: [Types.ObjectId], ref: 'User', default: [] },
    //     owner: { type: Types.ObjectId, ref: 'User', required: true }
});

apartSchema.index({ name: 1 }, {
    collation: {
        locale: 'en',
        strength: 2
    }
})

const Apart = model('Apart', apartSchema);

module.exports = Apart;


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