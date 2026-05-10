# Table Games Management System


## Core Features
1. Table Management: Create, update, and delete tables.
2. Fill Calculation: Calculate the refill needed to replenish the table's chips to the maximum capacity at end of shift.
3. Fill Request Logging: Log fill requests with details such as table number, amount requested, and timestamps. Allow to view and manage these logs.
4. Simple User Authentication: Implement a basic authentication system to restrict access to authorized personnel only.
5. Basic Dashboard: List Tables with their current chip counts, and provide an interface to manage tables 
1. fill requests.


To add a Main method, create a Program class with a static void Main(string[] args) method. 
Inside it, create an instance of your TableGamesManagementSystem class and call Run().

# Notes on further implementation
- When you list the current tables, you should be able to select a table and view details about that table.



- Request a fill/credit should probably be under the manage table screen
- Manage table should have the following options
    - Players
        - Position
        - Buy-in
        - Player History
            - History by month
            - History annually
            - Complete History
        - ID
            - Name
            - Address
            - DOB
            - Hair Color
            - Eye Color
            - Height
            - Weight
        - Players Card # - Can be null
    - Request a Fill
    - Request a Credit
    - Ante Tracking (track every time a black chip is dropped for ante  )


