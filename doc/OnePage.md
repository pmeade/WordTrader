Project Overview:
WordTrader is a browser-based social game that combines word challenges and trading with a simulated blockchain economy. The game aims to be educational, entertaining, and community-driven, without financial risks.

High-Level Architecture:

1. Client-Side (Frontend)
   2. Game Client: Built using Unity, running in a browser with potential future support for iOS and Android.
   3. Word Challenges: Interfaces for players to participate in various game modes like Ghost Game.
   4. Inventory Management: Allows players to manage their word tiles and other in-game assets.
   5. Voting Mechanism: Players vote on game proposals using virtual tokens, influencing game development.
2. Server-Side (Backend)
   3. Game Server: Manages game state, player interactions, and game logic not handled on the client-side.
   4. API Layer: Exposes endpoints for client interactions (e.g., starting games, submitting words, inventory management).
   5. Database: Centralized database (options: MongoDB, PostgreSQL, Firebase) storing player data, game states, and transaction data.
   6. Authentication: Ensures secure player login and interaction, potentially integrating with OAuth for secure login.
   7. Hosting: Hosted on Digital Ocean with scalable infrastructure.
3. Simulated Blockchain Integration
   4. Simulated Blockchain: Centralized database mimics blockchain transactions for word ownership and trading.
   5. NFT Management: Manages the creation, ownership, and trading of virtual NFTs representing in-game assets.
   6. DAO (Decentralized Autonomous Organization): On Ethereum, for donators who fund server maintenance and influence game development through token-based voting.
   7. ERC20 Tokens: Used within the DAO for voting and other governance activities.
   8. Key Technologies:

Frontend: Unity (C#)

Backend: To be decided; must handle core functionalities like authentication and game state management.

Database: Centralized database (options: MongoDB, PostgreSQL, Firebase)

Blockchain: Simulated blockchain for in-game transactions, Ethereum for DAO

Authentication: OAuth, JWT

Development and Deployment:

Version Control: GitHub for source code management.

Continuous Integration/Continuous Deployment (CI/CD): GitHub Actions for automating testing and deployment.

Hosting: Digital Ocean for backend and database hosting.
