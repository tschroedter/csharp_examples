Feature: WinnerPhaser

@straightFlush
Scenario: WinnerPhaser returns single winner for one player with Straight Flush
    Given player 'one' holds the following cards '2C,3C,4C,5C,6C'
    And player 'two' holds the following cards '2H,4H,6H,8H,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'StraightFlush'

@straightFlushTwoTimes
Scenario: WinnerPhaser returns single winner for two players with Straight Flush
    Given player 'one' holds the following cards '2C,3C,4C,5C,6C'
    And player 'two' holds the following cards '3H,4H,5H,6H,7H'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'StraightFlush'