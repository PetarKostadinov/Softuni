class footballTeam {
    constructor(clubName, country ) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = []; 
        this.addedNames = [];
    }
 
    newAdditions(footballPlayers){
        footballPlayers.forEach(x => {
            let [name, age, playerValue] = x.split('/');
            let player = this.invitedPlayers.find(x => x.name == name);    
            if(!player) {
                this.invitedPlayers.push({ name, age, playerValue });
 
                if(this.addedNames.every(x => x != name))
                    this.addedNames.push(name);
            } else {
                if (Number(player.playerValue) < Number(playerValue) ) {
                    player.playerValue = playerValue;
                }
            }
        })
 
        return `You successfully invite ${Array.from(this.addedNames).join(', ')}.`;
    }
 
    signContract(selectedPlayer){
        let [name, playerOffer] = selectedPlayer.split('/');
        let player = this.invitedPlayers.find(x => x.name == name);  
        if(!player) {
            throw new Error(`${name} is not invited to the selection list!`)
        }
        if(Number(playerOffer) < Number(player.playerValue)) {
            let priceDifference =  Number(player.playerValue) - Number(playerOffer);
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`);
        }
 
        player.playerValue = 'Bought';
        return `Congratulations! You sign a contract with ${name} for ${Number(playerOffer)} million dollars.`;
    }
 
    ageLimit(name, age){
        let player = this.invitedPlayers.find(x => x.name == name);  
        if(!player) {
            throw new Error(`${name} is not invited to the selection list!`)
        }
        if(Number(age) > Number(player.age)) {
            let ageDifference =  Number(age) - Number(player.age);
            if (5 > ageDifference) {
                return `${player.name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            }
            if (5 < ageDifference) {
                return `${player.name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        } else {
            return `${player.name} is above age limit!`;
        }
    }
 
    transferWindowResult(){
        let sortedPlayers = this.invitedPlayers.sort((a,b) => a.name.localeCompare(b.name));
        let resultMessage = 'Players list:\n';
        sortedPlayers.forEach(x => {
            resultMessage += `Player ${x.name}-${x.playerValue}\n`;
        });
 
        return resultMessage.trim();
    }
}
let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.signContract("Kylian Mbappé/240"));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.transferWindowResult());