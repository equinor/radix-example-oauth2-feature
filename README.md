# Radix OAuth2 feature example application

Sample application demonstrating how to configure oauth2 authentication using  the oauth2 feature in Radix.

Three `web` components are defined in radixconfig.yaml
- web-redis-internal  
  Uses the redis component as session store
- web-redis-external  
  Uses an Azure Cache for Redis service as session store
- web-cookie  
  Uses cookies as session store


Read the [documentation](https://www.radix.equinor.com/references/reference-radix-config/#oauth2)  and [guide](https://www.radix.equinor.com/guides/authentication/#using-the-radix-oauth2-feature) for more information.

