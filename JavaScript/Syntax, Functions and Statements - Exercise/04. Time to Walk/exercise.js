
function solve(steps, footprintMeeters, kmPerHour) {

    const secondsInHour = 3600;
    const meetersInKm = 1000;
    const minutesInHour = 60;
    const distanceForBreak = 500;

    const meetersPerSecond = kmPerHour * meetersInKm / secondsInHour;
    const distance = steps * footprintMeeters;
    const rest = Math.floor(distance / distanceForBreak) * minutesInHour;
    let time = distance / meetersPerSecond + rest;

    const hours = Math.floor(time / secondsInHour).toFixed(0).padStart(2, "0");
    const minutes = Math.floor(time / minutesInHour).toFixed(0).padStart(2, "0");
    const seconds = (time % minutesInHour).toFixed(0).padStart(2, "0");

    time = `${hours}:${minutes}:${seconds}`;

    return time;
}

console.log(solve(4000, 0.60, 5));
console.log(solve(2564, 0.70, 5.5));