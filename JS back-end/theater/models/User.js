const { Schema, model } = require('mongoose');

//TODO add User properties and validation according to assignment
const userSchema = new Schema({

    username: {
        type: String,
        required: true,
        unique: true,
        match: [/^[a-zA-Z0-9]+$/i, 'Username may contains only english letters and numbers'],
    },
    hashedPassword: { type: String, required: true },
    likedPlays: [{ type: Schema.Types.ObjectId, ref: 'Play' }]
});

userSchema.index({ username: 1 }, {
    collation: {
        locale: 'en',
        strength: 2
    }
});

const User = model('User', userSchema);

module.exports = User;