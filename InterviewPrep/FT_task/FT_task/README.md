# Markets Data App
    This project is a Markets Data App that fetches real-time market data and displays it in a user-friendly interface. It allows users to view the latest quotes for various financial symbols and provides links to additional information for each symbol.

# Features
    Fetches real-time market data from the FT Markets Data API.
    Displays the market data in a clean and organized format.
    Provides clickable links to additional information for each symbol.
    Handles error cases and displays appropriate messages.
    Responsive design for optimal viewing on different screen sizes.
# Prerequisites
    Node.js and npm (or yarn) should be installed on your machine.
# Installation
    Install the required dependencies by running npm install or yarn install.
# Usage
    Run the project using using Live Server (Live server extension should be installed/enabled in VScode).
    Right click on the index.html file and select open with Live Server - this will open the app in the browser.
    The app will display the latest market data for the specified symbols.
    If data is not available or an error occurs, an appropriate message will be displayed.
    Click on the symbol names or links to navigate to the corresponding detailed information pages.
# Testing
    Integration tests have been implemented to ensure the correctness of critical functionality.
    Run the tests by opening new terminal and command mocha tests
# Documentation
    The project follows a modular structure with clear separation of concerns.
    Each file and directory has a specific purpose, responsibility and appropriate name.
# Error Handling
    The app handles potential errors during data fetching and building the elements and displays appropriate messages.
# Responsiveness
    The app is designed to be responsive and adapt to different screen sizes.
    The layout and formatting adjust based on the screen dimensions.
    Styles are separated to style.css and responsive.css for easy modyfication.
# Accessibility
    The app strives to follow accessibility best practices.
    Proper semantic HTML tags and ARIA attributes are used for improved accessibility.
    The project is built using JavaScript and runs in the browser.
    It utilizes the Fetch API for making HTTP requests.
    No client-side frameworks or libraries (e.g., Angular, React, jQuery) are used.
# Modification
   - Adding new item to the list in 2 steps:
     1.Open fetchDat file -> Add the necessary symbol to const symbols.
     2.Open symbolMappings file -> Add the necessary name and link according to the symbol, following the patern.
   - Removing Item:
     1.Open fetchDat file -> Remove the unnecessary symbol from const symbols.