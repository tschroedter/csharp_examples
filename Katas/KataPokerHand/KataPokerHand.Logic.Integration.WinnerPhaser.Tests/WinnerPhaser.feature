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

@fourOfAKind
Scenario: WinnerPhaser returns single winner for one player with Four Of A Kind
    Given player 'one' holds the following cards '2C,2D,2S,2H,3C'
    And player 'two' holds the following cards '2H,4C,6H,8C,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'FourOfAKind'

@fourOfAKindTwoTimes
Scenario: WinnerPhaser returns single winner for two players with Four Of A Kind
    Given player 'one' holds the following cards '2C,2D,2S,2H,3C'
    And player 'two' holds the following cards '3C,3D,3S,3H,JH'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'FourOfAKind'

@fullHouse
Scenario: WinnerPhaser returns single winner for one player with FullHouse
    Given player 'one' holds the following cards '2C,2D,2S,3C,3C'
    And player 'two' holds the following cards '2H,4C,6H,8C,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'FullHouse'

@fullHouseTwoTimes
Scenario: WinnerPhaser returns single winner for two players with FullHouse
    Given player 'one' holds the following cards '2C,2D,2S,3C,3C'
    And player 'two' holds the following cards '2H,2D,4C,4H,4S'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'FullHouse'

@flush
Scenario: WinnerPhaser returns single winner for one player with Flush
    Given player 'one' holds the following cards '2C,4C,6C,8C,JC'
    And player 'two' holds the following cards '2H,4S,6H,8S,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'Flush'

@flushTwoTimes
Scenario: WinnerPhaser returns single winner for two players with Flush
    Given player 'one' holds the following cards '2C,4C,6C,8C,JC'
    And player 'two' holds the following cards '3C,5C,7C,9C,QC'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'Flush'

@straight
Scenario: WinnerPhaser returns single winner for one player with Straight
    Given player 'one' holds the following cards '2C,3S,4C,5S,6C'
    And player 'two' holds the following cards '2H,4S,6H,8S,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'Straight'

@straightTwoTimes
Scenario: WinnerPhaser returns single winner for two players with Straight
    Given player 'one' holds the following cards '2C,3S,4C,5S,6C'
    And player 'two' holds the following cards '3C,4S,5C,6S,7C'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'Straight'

@threeOfAKind
Scenario: WinnerPhaser returns single winner for one player with ThreeOfAKind
    Given player 'one' holds the following cards '2C,2S,2H,5S,6C'
    And player 'two' holds the following cards '2H,4S,6H,8S,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'ThreeOfAKind'

@threeOfAKindTwoTimes
Scenario: WinnerPhaser returns single winner for two players with ThreeOfAKind
    Given player 'one' holds the following cards '2C,2S,2H,5S,6C'
    And player 'two' holds the following cards '3H,3S,3H,8S,JH'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'ThreeOfAKind'

@twoPairs
Scenario: WinnerPhaser returns single winner for one player with TwoPairs
    Given player 'one' holds the following cards '2C,2S,3H,3S,6C'
    And player 'two' holds the following cards '2H,4S,6H,8S,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'TwoPairs'

@twoPairsTwoTimes
Scenario: WinnerPhaser returns single winner for two players with TwoPairs
    Given player 'one' holds the following cards '2C,2S,3H,3S,6C'
    And player 'two' holds the following cards '3C,3S,4H,4S,6S'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'TwoPairs'

@onePair
Scenario: WinnerPhaser returns single winner for one player with OnePair
    Given player 'one' holds the following cards '2C,2S,3H,4S,6C'
    And player 'two' holds the following cards '2H,4S,6H,8S,JH'
    When I press phase
    Then the winner should be player 'one'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'OnePair'

@onePairTwoTimes
Scenario: WinnerPhaser returns single winner for two players with OnePair
    Given player 'one' holds the following cards '2C,2S,3H,4S,6C'
    And player 'two' holds the following cards '3C,3S,6H,8S,JH'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'OnePair'

@onePairTwoTimesHighCard
Scenario: WinnerPhaser returns single winner for two players with OnePair using HighCard rule
    Given player 'one' holds the following cards '2C,2S,3H,4S,6C'
    And player 'two' holds the following cards '2D,2H,3D,4S,JH'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'OnePair'

@highCard
Scenario: WinnerPhaser returns single winner for two players with HighCard
    Given player 'one' holds the following cards '2C,4S,6H,8S,JC'
    And player 'two' holds the following cards '3C,5S,7H,9S,QH'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'HighCard'

@highCardOneDifferent
Scenario: WinnerPhaser returns single winner for two players with HighCard and only one card different
    Given player 'one' holds the following cards '2C,4S,6H,8S,JC'
    And player 'two' holds the following cards '2H,4C,6S,8H,QH'
    When I press phase
    Then the winner should be player 'two'
    And the winner property should show 'SingleWinner'
    And the winner should have won with status 'HighCard'
