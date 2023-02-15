const {
    Schema,
    model,
    Types
} = require('mongoose');

const URL_PATERN = /http(s)?:\/\/./i;

const CryptoSchema = new Schema({
    name: {
        type: String,
        minlength: [2, 'Name must be at least 2 characters long']
    },
    image: {
        type: String,
        validate: {
            validator: (value) => URL_PATERN.test(value),
            message: 'Invalid URL'
        }
    },
    price: {
        type: Number,
        required: true,
        min: [1, 'Minimum price required 1'],
       // max: [100, 'Maximum free rooms required 100'],
        default: 0
    },
    description: {
        type: String,
        minlength: [10, 'Description name must be at least 10 characters long']
    },
    payment: {
        type: String,
        enum: ['crypto-wallet', 'credit-card', 'debit-card', 'paypal']
    },
    buyCryptoUsers: {
        type: [Types.ObjectId],
        ref: 'User',
        default: []
    },
    owner: {
        type: Types.ObjectId,
        ref: 'User',
        required: true
    }


    // name: { type: String, minlength: [4, 'Crypto name must be at least 4 characters long'] },
    // city: { type: String, minlength: [3, 'City must be at least 3 characters long'] },
    // freeRooms: {
    //     type: Number, required: true,
    //     min: [1, 'Minimum free rooms required 1'],
    //     max: [100, 'Maximum free rooms required 100'],
    //     default: 0
    // },
    // image: {
    //     type: String, validate: {
    //         validator: (value) => URL_PATERN.test(value),
    //         message: 'Invalid URL'
    //     }
    // },
    // usersBooked: { type: [Types.ObjectId], ref: 'User', default: [] },
    // owner: { type: Types.ObjectId, ref: 'User', required: true }
});

CryptoSchema.index({
    name: 1
}, {
    collation: {
        locale: 'en',
        strength: 2
    }
})

const Crypto = model('Crypto', CryptoSchema);

module.exports = Crypto;


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