# Rainfall API Test Suite

## Overview

This test suite is designed to validate new functionality added to the Rainfall API that is used to report rainfall from measurement stations around the UK.

## API Documentation

You can find a summary of the API documentation [here](https://environment.data.gov.uk/flood-monitoring/doc/rainfall#api-summary).

## Test Objectives

- A request to test the limit parameter for rainfall measurements for an individual station [x]

- A request to test the date parameter for rainfall measurements for an individual station [x]

## Setup Instructions

1. Clone the repository.
2. Open the project in your preferred .NET IDE (e.g., Visual Studio).
3. Run the test suite directly to validate functionality.

## Future Considerations (If I Had More Time)

1. **Response Validation Improvements**  
   Currently, the response validation is done manually by checking specific fields. A better approach would be to use **schema validation**. Tools like JSON schema validators can ensure the structure and types of the response data are as expected. This would not only make the validation process more robust but also easier to maintain and scale.

2. **CI/CD Integration**  
   Incorporating a continuous integration (CI) tool like **GitHub Actions** or another CI platform would automate the testing process. This would allow the tests to run automatically on each pull request or push, ensuring the codebase is always tested and any issues are caught early.

3. **Parallel Test Execution**  
   Enabling NUnit's **parallelizable feature** would allow tests to run concurrently, significantly speeding up the test execution time. This would be especially useful as the number of tests increases, making the test suite more efficient.

4. **Codebase Refactoring for Readability**  
   To improve code readability and maintainability, the project can be restructured. For example, separating the code for API requests into their own **request files and folders** would make it easier to manage and extend the codebase in the future.

5. **Secure Storage of API Endpoints**  
   Currently, API endpoints are hardcoded in the code. A better approach would be to **store the API endpoints securely** using configuration files or environment variables. This would make the code more flexible and secure, as sensitive information like API base URLs or keys would be kept outside the source code.