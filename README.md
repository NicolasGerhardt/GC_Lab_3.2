# Lab 3.2 - Shopping List
## Task
Make a shopping list application which uses collections to store your items.

## What will the application do?
* Display a list of at least 8 item names and prices
* Ask the user to enter an item name
  * If that item exists, display that item and price and add that item and its price to the user’s order.
  * If that item doesn’t exist, display an error and re-prompt the user. (Display the menu again if you’d like.)
* Ask if they want to add another. Repeat if they do. (User can enter an item more than once; we’re not taking quantity at this point.)
* When they’re done adding items, display a list of all items ordered with prices in columns.
* Display the average price of items ordered.

## Build Specifications/Grading Points
* Application uses a Dictionary <string, double> to keep track of the menu of items. You can code it with literals. (2 points for instantiation & initialization)
* Application uses parallel ArrayLists (one of strings, one of doubles) to store the items ordered and their prices. (2 point for setting up empty lists)
* Application takes item name input and:
  * Responds if that item doesn’t exist (1 point)
  * Adds its name and price to the relevant ArrayLists if it does (1 point)
* Application asks user if they want to quit or continue, and loops appropriately (1 point)
* Application displays list of items with their prices (2 points)
* Application displays correct average for list (1 point)

## Extended Challenges
* Implement a menu system so the user can enter just a letter or number for the item.
* Make a third ArrayList for quantities of items ordered and allow the user to order more than one at a time.
  * Extended extended: If they order an item already in their cart, increase the quantity rather than adding another entry.
* Display the most and least expensive item ordered.
