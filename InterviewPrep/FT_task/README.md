Markets Data App
This project is a Markets Data App that fetches real-time market data and displays it in a user-friendly interface. It allows users to view the latest quotes for various financial symbols and provides links to additional information for each symbol.

# Features
1. Fetches real-time market data from the FT Markets Data API.
2. Displays the market data in a clean and organized format.
3. Provides clickable links to additional information for each symbol.
4. Handles error cases and displays appropriate messages.
5. Responsive design for optimal viewing on different screen sizes.

# Usage
1. Run the project using Live Server.
2. The app will display the latest market data for the specified symbols.
3. If data is not available or an error occurs, an appropriate message will be displayed.
4. Click on the symbol names or links to navigate to the corresponding detailed information pages.

# Testing
1. Unit tests have been implemented to ensure the correctness of critical functionality.
2. Run the tests using the command npm test or yarn test.

# Documentation
> The project follows a modular structure with clear separation of concerns.
Each file and function has a specific purpose and responsibility.

# Error Handling
1. The app handles potential errors during data fetching and displays appropriate messages.

# Responsiveness
1. The app is designed to be responsive and adapt to different screen sizes.
2. The layout and formatting adjust based on the screen dimensions.

# Accessibility
1. The app strives to follow accessibility best practices.
2. Proper semantic HTML tags and ARIA attributes are used for improved accessibility.

# Frameworks and Libraries
1. No client-side frameworks or libraries (e.g., Angular, React, jQuery) are used.
2. The project is built using JavaScript and runs in the browser.

# Limitations and Known Issues
1. The app currently only supports symbols provided in the symbols constant.
2. Data for additional symbols may not be available or may require additional configuration.
3. The project is a simplified version for demonstration purposes and may not handle all edge cases.