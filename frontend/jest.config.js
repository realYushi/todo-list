export default {
    testEnvironment: "node",
    testMatch: [
        "**/tests/unit-tests/**/*.js", // Matches any JavaScript files under unit-tests
        // "**/tests/feature-tests/**/*.js", // Matches any JavaScript files under feature-tests
        // "**/?(*.)+(spec|test).[tj]s?(x)", // Matches all other test/spec files across the project
    ],
    moduleFileExtensions: ["js", "jsx", "ts", "tsx", "json", "node"],
    // Additional configurations like setupFiles, coverage options, etc., can go here
};
