Feature: CardsRankEngine
         The engine is used to rank a set of 5 cards.

@straightFlush
Scenario: Engine detects straight flush
       Given I added a card 'two of clubs' to player cards
       And I added a card 'three of clubs' to player cards
       And I added a card 'four of clubs' to player cards
       And I added a card 'five of clubs' to player cards
       And I added a card 'six of clubs' to player cards
       When I apply the rules
       Then the status should be 'StraightFlush'
       And the HighestCard should be 'six of Clubs'

@fourOfAKind
Scenario: Engine detects four of a kind
       Given I added a card 'two of clubs' to player cards
       And I added a card 'two of spades' to player cards
       And I added a card 'two of hearts' to player cards
       And I added a card 'two of diamonds' to player cards
       And I added a card 'six of clubs' to player cards
       When I apply the rules
       Then the status should be 'FourOfAKind'
       And the HighestCard should be 'six of Clubs'
       And the FourOfAKind should be 'two of clubs, two of spades, two of hearts, two of diamonds'
       And the Rank should be 'two'

@fullHouse
Scenario: Engine detects full house
       Given I added a card 'two of clubs' to player cards
       And I added a card 'two of spades' to player cards
       And I added a card 'two of hearts' to player cards
       And I added a card 'three of diamonds' to player cards
       And I added a card 'three of clubs' to player cards
       When I apply the rules
       Then the status should be 'FullHouse'
       And the TwoOfAkind should be 'three of diamonds, three of clubs'
       And the ThreeOfAkind should be 'two of clubs, two of spades, two of hearts'

@straight
Scenario: Engine detects straight
       Given I added a card 'two of clubs' to player cards
       And I added a card 'three of spades' to player cards
       And I added a card 'four of hearts' to player cards
       And I added a card 'five of diamonds' to player cards
       And I added a card 'six of clubs' to player cards
       When I apply the rules
       Then the status should be 'Straight'
       And the HighestCard should be 'six of Clubs'

@threeOfAKind
Scenario: Engine detects three of a kind
       Given I added a card 'two of clubs' to player cards
       And I added a card 'two of spades' to player cards
       And I added a card 'two of hearts' to player cards
       And I added a card 'three of diamonds' to player cards
       And I added a card 'four of clubs' to player cards
       When I apply the rules
       Then the status should be 'ThreeOfAKind'
       And the ThreeOfAkind should be 'two of clubs, two of spades, two of hearts'
       And the Rank should be 'two'
       And the OtherCards should be 'three of diamonds, four of clubs'
       And the HighestCard should be 'four of Clubs'

@twoPairs
Scenario: Engine detects two pairs
       Given I added a card 'two of clubs' to player cards
       And I added a card 'two of spades' to player cards
       And I added a card 'three of hearts' to player cards
       And I added a card 'three of diamonds' to player cards
       And I added a card 'four of clubs' to player cards
       When I apply the rules
       Then the status should be 'TwoPairs'
       And the FirstPairOfCards should be 'two of clubs, two of spades'
       And the SecondPairOfCards should be 'three of hearts, three of diamonds'
       And the HighestCard should be 'four of clubs'
