
function solve(object) {

    if (object.dizziness === true) {

        object.levelOfHydrated += 0.1 * object.weight * object.experience;
        object.dizziness = false;
    }

    return object;
}

console.log(solve({
    weight: 80,
    experience: 1,
    levelOfHydrated: 0,
    dizziness: true
}
));
console.log(solve({
    weight: 120,
    experience: 20,
    levelOfHydrated: 200,
    dizziness: true
}
));

