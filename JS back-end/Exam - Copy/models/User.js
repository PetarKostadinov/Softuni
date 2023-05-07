const { Schema, model, Types } = require('mongoose');
const { isEmail } = require('validator');

//TODO add User properties and validation according to assignment
const userSchema = new Schema({
    username: {
        type: String, required: [true, 'Username is required'], minlength: [5, 'The username should be at least 5 characters long '],
        validate: { validator: (value) => onlyLettersAndNumbers(value),
        message: 'Username may contains only English letters and numbers' }
    },
    hashedPassword: { type: String, required: [true, 'Password is required'], minlength: [5, 'The password should be at least 5 characters long ']}
    // validate: { validator: (value) => onlyLettersAndNumbers(value),
    // message: 'Pasword may contains only English letters and numbers' }},
 
});

function onlyLettersAndNumbers(str) {
    return /^[a-z0-9]*$/.test(str);
}

userSchema.index({ username: 1 }, {
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema);

module.exports = User;



// email: { type: String, required: [true, 'Email is required'], validate: [isEmail, 'Invalid email'] },

// booked: { type: [Types.ObjectId], ref: 'User', default: [] },
// offeredHotels: { type: [Types.ObjectId], ref: 'User', default: [] },