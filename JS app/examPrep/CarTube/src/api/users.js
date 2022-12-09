import { clearUserData, setUserData } from "../util.js";
import { get, post } from "./api.js";


export async function login(username, password) {
    const { _id, username: resultUsername, accessToken } = await post('/users/login', { username, password });

    setUserData({
        _id,
        username: resultUsername,
        accessToken
    })
}

export async function register(username, password) {
    const { _id, username: resultusername, accessToken } = await post('/users/register', { username, password });

    setUserData({
        _id,
        username: resultusername,
        accessToken
    })
}

export async function logout() {
    get('/users/logout');
    clearUserData();
}

