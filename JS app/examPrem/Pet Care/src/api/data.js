import { get, del, put, post } from "./api.js";

export async function getAll() {
    return get('/data/pets?sortBy=_createdOn%20desc&distinct=name');

}

export async function getById(id) {
    return get('/data/pets/' + id);
}

export async function deleteById(id) {
    return del('/data/pets/' + id);
}

export async function create(petData) {

    return post('/data/pets', petData);
}

export async function edit(id, petData) {
    return put('/data/pets/' + id, petData);
}