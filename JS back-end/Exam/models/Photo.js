
const { Schema, model, Types } = require('mongoose');

const URL_PATERN = /http(s)?:\/\/./i;

const hotelSchema = new Schema({

    name: { type: String, minlength: [2, 'The name must be at least 2 characters long'] },
    age: {
        type: Number, required: true,
        min: [1, 'Minimum age required 1'],
        max: [100, 'Maximum age required 100'],
        default: 0
    },
    image: {
        type: String, validate: {
            validator: (value) => URL_PATERN.test(value),
            message: 'Invalid URL'
        }
    },
    description: { type: String, min: [5, 'Description must be between 5 and 50 characters long'],
    maxlength: [50, 'Description must be between 5 and 50 characters long'] 
    },
    location: { type: String, minlength: [5, 'Location must be between 5 and 50 characters long'],
    maxlength: [50, 'Location must be between 5 and 50 characters long']},

    commentList: [
       new Schema({
            userId:  String,
            username: String,
            comment: String,
        })
    ],


    owner: { type: Types.ObjectId, ref: 'User', required: true }
});

hotelSchema.index({ name: 1 }, {
    collation: {
        locale: 'en',
        strength: 2
    }
})

const Photo = model('Photo', hotelSchema);

module.exports = Photo;


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