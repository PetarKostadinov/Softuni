import {fetchData} from './fetchData.js';
import {showSpinner} from './spinner.js';
import {symbolMappings} from './symbolMappings.js';

const appElement = document.getElementById('app');
let marketsDataWrapperDiv = '';
let marketsDataUnorderedList = '';
let marketsDataListItem = '';
let articleHoldingLink = '';
let itemChange = '';
let spanPlusMinus = '';
let percentage = '';

try {
    fetchData().then((data) => {
        buildUI(data);
    });
} catch (error) {
    showSpinner();
}

function buildUI(data) {
    if (data.error) {
        showSpinner();
    } else {
        createElementsAndShowMarketsData(data);
    }
}

function createElementsAndShowMarketsData(data) {
    createDataWrapperDivAndUnorderedList();
    createListElementForEachItemAndAddData(data);
}

function createDataWrapperDivAndUnorderedList() {
    marketsDataWrapperDiv = document.createElement('div');
    marketsDataWrapperDiv.classList.add('markets-data-wrapper', 'js-markets-data');
    marketsDataUnorderedList = document.createElement('ul');
    marketsDataUnorderedList.classList.add('markets-data__items');
    appElement.appendChild(marketsDataWrapperDiv);
    marketsDataWrapperDiv.appendChild(marketsDataUnorderedList);
}

function createListElementForEachItemAndAddData(data) {
    data.forEach((item) => {
        if (item.quote.change1Day != 0) {
            marketsDataListItem = document.createElement('li');
            marketsDataListItem.classList.add('markets-data__item');
            marketsDataUnorderedList.appendChild(marketsDataListItem);

            addNameAndLinkFromMappedValueObject(item);
            addChange1DayPercent(item);

            itemChange.appendChild(spanPlusMinus);
            itemChange.appendChild(percentage);
            articleHoldingLink.appendChild(itemChange);
        }
    });
}

function addNameAndLinkFromMappedValueObject(item) {
    articleHoldingLink = document.createElement('a');
    articleHoldingLink.setAttribute('href', item.link);
    articleHoldingLink.classList.add('markets-data__item-link');
    marketsDataListItem.appendChild(articleHoldingLink);
    const itemSymbol = document.createElement('span');
    itemSymbol.classList.add('markets-data__item-name');
    const mappedValue = symbolMappings[item.symbolInput.slice()];

    if (mappedValue) {
        itemSymbol.textContent = mappedValue.name;
        if (mappedValue.link) {
            articleHoldingLink.setAttribute('href', mappedValue.link);
        }
    } else {
        itemSymbol.textContent = item.symbolInput.split(':')[0];
    }
    articleHoldingLink.appendChild(itemSymbol);
}

function addChange1DayPercent(item) {
    itemChange = document.createElement('span');
    itemChange.classList.add('markets-data__item-change');

    spanPlusMinus = document.createElement('span');
    percentage = document.createTextNode(
        Math.abs(item.quote.change1DayPercent.toFixed(2)) + '%'
    );

    if (item.quote.change1Day > 0) {
        spanPlusMinus.textContent = '+';
        itemChange.classList.add('markets-data__item-change--up');
    } else {
        spanPlusMinus.textContent = '−';
        itemChange.classList.add('markets-data__item-change--down');
    }
}
