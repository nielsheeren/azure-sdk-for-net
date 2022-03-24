// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ServiceBus
{
    /// <summary>
    /// A class representing a collection of <see cref="NamespaceTopicAuthorizationRuleResource" /> and their operations.
    /// Each <see cref="NamespaceTopicAuthorizationRuleResource" /> in the collection will belong to the same instance of <see cref="ServiceBusTopicResource" />.
    /// To get a <see cref="NamespaceTopicAuthorizationRuleCollection" /> instance call the GetNamespaceTopicAuthorizationRules method from an instance of <see cref="ServiceBusTopicResource" />.
    /// </summary>
    public partial class NamespaceTopicAuthorizationRuleCollection : ArmCollection, IEnumerable<NamespaceTopicAuthorizationRuleResource>, IAsyncEnumerable<NamespaceTopicAuthorizationRuleResource>
    {
        private readonly ClientDiagnostics _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics;
        private readonly TopicAuthorizationRulesRestOperations _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient;

        /// <summary> Initializes a new instance of the <see cref="NamespaceTopicAuthorizationRuleCollection"/> class for mocking. </summary>
        protected NamespaceTopicAuthorizationRuleCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NamespaceTopicAuthorizationRuleCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NamespaceTopicAuthorizationRuleCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceBus", NamespaceTopicAuthorizationRuleResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(NamespaceTopicAuthorizationRuleResource.ResourceType, out string namespaceTopicAuthorizationRuleTopicAuthorizationRulesApiVersion);
            _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient = new TopicAuthorizationRulesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, namespaceTopicAuthorizationRuleTopicAuthorizationRulesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ServiceBusTopicResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ServiceBusTopicResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates an authorization rule for the specified topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="parameters"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<NamespaceTopicAuthorizationRuleResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string authorizationRuleName, ServiceBusAuthorizationRuleData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ServiceBusArmOperation<NamespaceTopicAuthorizationRuleResource>(Response.FromValue(new NamespaceTopicAuthorizationRuleResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates an authorization rule for the specified topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="parameters"> The shared access authorization rule. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<NamespaceTopicAuthorizationRuleResource> CreateOrUpdate(WaitUntil waitUntil, string authorizationRuleName, ServiceBusAuthorizationRuleData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, parameters, cancellationToken);
                var operation = new ServiceBusArmOperation<NamespaceTopicAuthorizationRuleResource>(Response.FromValue(new NamespaceTopicAuthorizationRuleResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the specified authorization rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual async Task<Response<NamespaceTopicAuthorizationRuleResource>> GetAsync(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Get");
            scope.Start();
            try
            {
                var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NamespaceTopicAuthorizationRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns the specified authorization rule.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual Response<NamespaceTopicAuthorizationRuleResource> Get(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Get");
            scope.Start();
            try
            {
                var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NamespaceTopicAuthorizationRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets authorization rules for a topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules
        /// Operation Id: TopicAuthorizationRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NamespaceTopicAuthorizationRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NamespaceTopicAuthorizationRuleResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<NamespaceTopicAuthorizationRuleResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<NamespaceTopicAuthorizationRuleResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets authorization rules for a topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules
        /// Operation Id: TopicAuthorizationRules_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NamespaceTopicAuthorizationRuleResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NamespaceTopicAuthorizationRuleResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<NamespaceTopicAuthorizationRuleResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<NamespaceTopicAuthorizationRuleResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new NamespaceTopicAuthorizationRuleResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(authorizationRuleName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual Response<bool> Exists(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(authorizationRuleName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual async Task<Response<NamespaceTopicAuthorizationRuleResource>> GetIfExistsAsync(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<NamespaceTopicAuthorizationRuleResource>(null, response.GetRawResponse());
                return Response.FromValue(new NamespaceTopicAuthorizationRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}/authorizationRules/{authorizationRuleName}
        /// Operation Id: TopicAuthorizationRules_Get
        /// </summary>
        /// <param name="authorizationRuleName"> The authorization rule name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="authorizationRuleName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="authorizationRuleName"/> is null. </exception>
        public virtual Response<NamespaceTopicAuthorizationRuleResource> GetIfExists(string authorizationRuleName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(authorizationRuleName, nameof(authorizationRuleName));

            using var scope = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesClientDiagnostics.CreateScope("NamespaceTopicAuthorizationRuleCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _namespaceTopicAuthorizationRuleTopicAuthorizationRulesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, authorizationRuleName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<NamespaceTopicAuthorizationRuleResource>(null, response.GetRawResponse());
                return Response.FromValue(new NamespaceTopicAuthorizationRuleResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NamespaceTopicAuthorizationRuleResource> IEnumerable<NamespaceTopicAuthorizationRuleResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NamespaceTopicAuthorizationRuleResource> IAsyncEnumerable<NamespaceTopicAuthorizationRuleResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
