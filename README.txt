Getting started:

Now that you have installed the messaging framework do the following:

1) Verify that the selector framework has been correctly installed. To perform this verification
do the following:

	Set the environment variable CS_LIBREPO_HOME point to the location where the selector
	framework JARs have been installed. For example, if you installed the framework in d:\selector
	then the JARs will be located in d:\selector\lib\java.


2) Once the framework installation has been validated (see above) you can start doing some real work:

	Build your own selectors.

3) TIBCO Rendezvous:

	The framework provides built-in support for working with the TIBCO/Rendezvous product. In order to 
        use the TIBCO/Rendezvous functionality of the framework one additional JAR is required: tibrvj.jar. 
        Clients are expected to have access to this JAR (version 6.0 or higher) and the necessary 
	TIBCO/Rendezvous runtime license files. To download an evaluation copy of the TIBCO/Rendezvous product
	see http://www.tibco.com/solutions/products/active_enterprise/rv.

4) JMS:

	The framework provides built-in support for working with the JMS. In order to use the JMS functionality 
        of the framework clients are expected to have the necessary JARS.
