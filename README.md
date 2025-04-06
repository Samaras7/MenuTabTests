Test ma na celu sprawdzenie opcji zmiany w menu.
Reszta zaproponowanych testów:
                
                1. Displaying Menu Items

        Description: Ensure the list of menu items loads correctly when entering the Menu tab.

        Validation:

        Menu items are visible.

        No empty state if items exist.

        Placeholder or message if list is empty.

                2. Editing a Menu Item

        Description: User can edit an existing menu item and save changes.

        Steps:

        Click edit button on the first item.

        Change label

        Click Save.

        Verify new label appears on the list.

                3. Adding a New Menu Item

        Description: Staff can add new content to the menu.
                Steps:

        Open Add new form.

        Fill in required fields

        Click Save.

        Confirm new item is listed.

        Validation:

        All fields must be filled before save is enabled.

                4. Deleting a Menu Item

        Description: Menu items can be deleted with confirmation.

        Steps:

        Click the delete button on an item.
                Confirm the action.

        Verify the item disappears from the list.

                5. Handling API Errors Gracefully

        Description: Ensure the UI responds correctly to backend errors.

        Examples:

        Failed data fetch.

        Error during save or update.

        Expected Behavior:

        Error message shown.

        App does not crash or freeze.

        Retry options if applicable.

                6. Form Validation

        Description: Form must validate input before allowing submission.

        Scenarios:

        Required fields are empty.

        Invalid URLs or formats.

        Expected Behavior:

        Save button is disabled until valid.

        Field-level error messages shown.
