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
    /// A class representing a collection of <see cref="ServiceBusTopicResource" /> and their operations.
    /// Each <see cref="ServiceBusTopicResource" /> in the collection will belong to the same instance of <see cref="ServiceBusNamespaceResource" />.
    /// To get a <see cref="ServiceBusTopicCollection" /> instance call the GetServiceBusTopics method from an instance of <see cref="ServiceBusNamespaceResource" />.
    /// </summary>
    public partial class ServiceBusTopicCollection : ArmCollection, IEnumerable<ServiceBusTopicResource>, IAsyncEnumerable<ServiceBusTopicResource>
    {
        private readonly ClientDiagnostics _serviceBusTopicTopicsClientDiagnostics;
        private readonly TopicsRestOperations _serviceBusTopicTopicsRestClient;

        /// <summary> Initializes a new instance of the <see cref="ServiceBusTopicCollection"/> class for mocking. </summary>
        protected ServiceBusTopicCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="ServiceBusTopicCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal ServiceBusTopicCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _serviceBusTopicTopicsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.ServiceBus", ServiceBusTopicResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ServiceBusTopicResource.ResourceType, out string serviceBusTopicTopicsApiVersion);
            _serviceBusTopicTopicsRestClient = new TopicsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, serviceBusTopicTopicsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ServiceBusNamespaceResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ServiceBusNamespaceResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a topic in the specified namespace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="parameters"> Parameters supplied to create a topic resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<ServiceBusTopicResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string topicName, ServiceBusTopicData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _serviceBusTopicTopicsRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, topicName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new ServiceBusArmOperation<ServiceBusTopicResource>(Response.FromValue(new ServiceBusTopicResource(Client, response), response.GetRawResponse()));
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
        /// Creates a topic in the specified namespace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="parameters"> Parameters supplied to create a topic resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<ServiceBusTopicResource> CreateOrUpdate(WaitUntil waitUntil, string topicName, ServiceBusTopicData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _serviceBusTopicTopicsRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, topicName, parameters, cancellationToken);
                var operation = new ServiceBusArmOperation<ServiceBusTopicResource>(Response.FromValue(new ServiceBusTopicResource(Client, response), response.GetRawResponse()));
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
        /// Returns a description for the specified topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_Get
        /// </summary>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        public virtual async Task<Response<ServiceBusTopicResource>> GetAsync(string topicName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.Get");
            scope.Start();
            try
            {
                var response = await _serviceBusTopicTopicsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, topicName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServiceBusTopicResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Returns a description for the specified topic.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_Get
        /// </summary>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        public virtual Response<ServiceBusTopicResource> Get(string topicName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.Get");
            scope.Start();
            try
            {
                var response = _serviceBusTopicTopicsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, topicName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new ServiceBusTopicResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all the topics in a namespace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics
        /// Operation Id: Topics_ListByNamespace
        /// </summary>
        /// <param name="skip"> Skip is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skip parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N usageDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ServiceBusTopicResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<ServiceBusTopicResource> GetAllAsync(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<ServiceBusTopicResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serviceBusTopicTopicsRestClient.ListByNamespaceAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServiceBusTopicResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<ServiceBusTopicResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _serviceBusTopicTopicsRestClient.ListByNamespaceNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, top, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ServiceBusTopicResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all the topics in a namespace.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics
        /// Operation Id: Topics_ListByNamespace
        /// </summary>
        /// <param name="skip"> Skip is only used if a previous operation returned a partial result. If a previous response contains a nextLink element, the value of the nextLink element will include a skip parameter that specifies a starting point to use for subsequent calls. </param>
        /// <param name="top"> May be used to limit the number of results to the most recent N usageDetails. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ServiceBusTopicResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<ServiceBusTopicResource> GetAll(int? skip = null, int? top = null, CancellationToken cancellationToken = default)
        {
            Page<ServiceBusTopicResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serviceBusTopicTopicsRestClient.ListByNamespace(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServiceBusTopicResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<ServiceBusTopicResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _serviceBusTopicTopicsRestClient.ListByNamespaceNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skip, top, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ServiceBusTopicResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_Get
        /// </summary>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string topicName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(topicName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_Get
        /// </summary>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        public virtual Response<bool> Exists(string topicName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(topicName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_Get
        /// </summary>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        public virtual async Task<Response<ServiceBusTopicResource>> GetIfExistsAsync(string topicName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _serviceBusTopicTopicsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, topicName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<ServiceBusTopicResource>(null, response.GetRawResponse());
                return Response.FromValue(new ServiceBusTopicResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ServiceBus/namespaces/{namespaceName}/topics/{topicName}
        /// Operation Id: Topics_Get
        /// </summary>
        /// <param name="topicName"> The topic name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="topicName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="topicName"/> is null. </exception>
        public virtual Response<ServiceBusTopicResource> GetIfExists(string topicName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topicName, nameof(topicName));

            using var scope = _serviceBusTopicTopicsClientDiagnostics.CreateScope("ServiceBusTopicCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _serviceBusTopicTopicsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, topicName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<ServiceBusTopicResource>(null, response.GetRawResponse());
                return Response.FromValue(new ServiceBusTopicResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<ServiceBusTopicResource> IEnumerable<ServiceBusTopicResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<ServiceBusTopicResource> IAsyncEnumerable<ServiceBusTopicResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
