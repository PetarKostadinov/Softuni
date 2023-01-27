const { Schema, model, Types } = require('mongoose');
const { isEmail } = require('validator');

//TODO add User properties and validation according to assignment
const userSchema = new Schema({
    name: {
        type: String, required: [true, 'Name is required'], validate: {
            validator: (value) => firstAndLastName(value),
            message: 'Please enter correct first name and last name'
        }
    },
    username: { type: String, required: [true, 'Username is required'], milength: [5, 'Username must be atleast 5 characters long'] },
    hashedPassword: { type: String, required: [true, 'Password is required'], milength: [4, 'Password must be atleast 4 characters long'] }

    // email: { type: String, required: [true, 'Email is required'], validate: [isEmail, 'Invalid email'] },
    // username: {
    //     type: String, required: [true, 'Username is required'],
    //     validate: { validator: (value) => onlyLettersAndNumbers(value),
    //     message: 'Username may contains only English letters and numbers' }
    // },
    // hashedPassword: { type: String, required: [true, 'Password is required'] },
    // booked: { type: [Types.ObjectId], ref: 'User', default: [] },
    // offeredHotels: { type: [Types.ObjectId], ref: 'User', default: [] },
});

function firstAndLastName(str) {
    return /^[A-Z][a-z]+\s[A-Z][a-z]+$/.test(str);
}

function onlyLettersAndNumbers(str) {
    return /^[A-Za-z0-9]*$/.test(str);
}

userSchema.index({ username: 1 }, {
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema);

module.exports = User;