
const dotenv = require('dotenv');
dotenv.config();

module.exports = {
    // Set environment variables or hard-code here
    credentials: {
        client_id: process.env.NODE_ENV === 'production' ? process.env.FORGE_CLIENT_ID : process.env.TEST_FORGE_CLIENT_ID,
        client_secret: process.env.NODE_ENV === 'production' ? process.env.FORGE_CLIENT_SECRET : process.env.TEST_FORGE_CLIENT_SECRET,
        callback_url: process.env.NODE_ENV === 'production' ? process.env.FORGE_CALLBACK_URL : process.env.TEST_FORGE_CALLBACK_URL
    },
    scopes: {
        // Required scopes for the server-side application
        internal: ['bucket:create', 'bucket:read','bucket:delete', 'data:read', 'data:create', 'data:write', 'account:read'],
        internal_2legged: ['code:all', 'bucket:create', 'bucket:read', 'data:read', 'data:create', 'data:write','account:read','bucket:delete'],
        // Required scope for the client-side viewer
        public: ['viewables:read']
    },
    designAutomation: {
        endpoint: 'https://developer.api.autodesk.com/da/us-east/v3/',
        webhook_url: process.env.NODE_ENV === 'production' ? process.env.TEST_FORGE_WEBHOOK_URL : process.env.TEST_FORGE_WEBHOOK_URL,
        nickname: process.env.NODE_ENV === 'production' ? process.env.DESIGN_AUTOMATION_NICKNAME : process.env.TEST_DESIGN_AUTOMATION_NICKNAME,
        activity_name: process.env.DESIGN_AUTOMATION_ACTIVITY_NAME,
        appbundle_activity_alias: 'dev',

        URL: {
            GET_ENGINES_URL: "https://developer.api.autodesk.com/da/us-east/v3/engines",
            ACTIVITIES_URL: "https://developer.api.autodesk.com/da/us-east/v3/activities",
            ACTIVITY_URL: "https://developer.api.autodesk.com/da/us-east/v3/activities/",
            APPBUNDLES_URL: "https://developer.api.autodesk.com/da/us-east/v3/appbundles",
            APPBUNDLE_URL: "https://developer.api.autodesk.com/da/us-east/v3/appbundles/",

            CREATE_APPBUNDLE_VERSION_URL: "https://developer.api.autodesk.com/da/us-east/v3/appbundles/",
            CREATE_APPBUNDLE_ALIAS_URL: "https://developer.api.autodesk.com/da/us-east/v3/appbundles/",

            UPDATE_APPBUNDLE_ALIAS_URL: "https://developer.api.autodesk.com/da/us-east/v3/appbundles/",
            CREATE_ACTIVITY_ALIAS: "https://developer.api.autodesk.com/da/us-east/v3/activities/",
        }
    },
   
};
