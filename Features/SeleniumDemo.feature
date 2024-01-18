Feature: Selenium Demo


@tag1
Scenario: Add and Delete Element
        Given I open the browser
        When I navigate to the website "https://the-internet.herokuapp.com/add_remove_elements/"
        Then the title of the website should be "The Internet"
        And the URL of the website should be "https://the-internet.herokuapp.com/add_remove_elements/"
        When I click the "Add Element" button
        Then the "Delete" button should be displayed
        And the text of the "Delete" button should be "Delete"
        And I close the browser