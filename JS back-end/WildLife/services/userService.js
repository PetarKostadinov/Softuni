const bcrypt = require('bcrypt');
const jwt = require('jsonwebtoken');
const User = require('../models/User');

const JWT_SECRET = 'dfgerhsrtdge433';

async function register(firstName, lastName, email, password) {
    const existing = await User.findOne({ email: new RegExp(`^${email}$`, 'i') });
    console.log(existing)
    if (existing) {
        throw new Error('Username is taken');
    }

    const hashedPassword = await bcrypt.hash(password, 10);

    const user = new User({
        firstName,
        lastName,
        email,
        hashedPassword
    });
    await user.save();

    //TODO see assignment if registration creates user session
    return user;
}

async function login(email, password) {
    const user = await User.findOne({ email }).collation({ locale: 'en', strength: 2 });
    if (!user) {
        throw new Error('Incorect username or password');
    }

    const hasMatch = await bcrypt.compare(password, user.hashedPassword);

    if (hasMatch == false) {
        throw new Error('Incorect username or password');
    }

    return user;
}

module.exports = {
    register,
    login
}