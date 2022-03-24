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
using Azure.ResourceManager.Sql.Models;

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="BackupShortTermRetentionPolicyResource" /> and their operations.
    /// Each <see cref="BackupShortTermRetentionPolicyResource" /> in the collection will belong to the same instance of <see cref="SqlDatabaseResource" />.
    /// To get a <see cref="BackupShortTermRetentionPolicyCollection" /> instance call the GetBackupShortTermRetentionPolicies method from an instance of <see cref="SqlDatabaseResource" />.
    /// </summary>
    public partial class BackupShortTermRetentionPolicyCollection : ArmCollection, IEnumerable<BackupShortTermRetentionPolicyResource>, IAsyncEnumerable<BackupShortTermRetentionPolicyResource>
    {
        private readonly ClientDiagnostics _backupShortTermRetentionPolicyClientDiagnostics;
        private readonly BackupShortTermRetentionPoliciesRestOperations _backupShortTermRetentionPolicyRestClient;

        /// <summary> Initializes a new instance of the <see cref="BackupShortTermRetentionPolicyCollection"/> class for mocking. </summary>
        protected BackupShortTermRetentionPolicyCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="BackupShortTermRetentionPolicyCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal BackupShortTermRetentionPolicyCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _backupShortTermRetentionPolicyClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", BackupShortTermRetentionPolicyResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(BackupShortTermRetentionPolicyResource.ResourceType, out string backupShortTermRetentionPolicyApiVersion);
            _backupShortTermRetentionPolicyRestClient = new BackupShortTermRetentionPoliciesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, backupShortTermRetentionPolicyApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlDatabaseResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlDatabaseResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Updates a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="parameters"> The short term retention policy info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<BackupShortTermRetentionPolicyResource>> CreateOrUpdateAsync(WaitUntil waitUntil, ShortTermRetentionPolicyName policyName, BackupShortTermRetentionPolicyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _backupShortTermRetentionPolicyRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<BackupShortTermRetentionPolicyResource>(new BackupShortTermRetentionPolicyOperationSource(Client), _backupShortTermRetentionPolicyClientDiagnostics, Pipeline, _backupShortTermRetentionPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Updates a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="parameters"> The short term retention policy info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<BackupShortTermRetentionPolicyResource> CreateOrUpdate(WaitUntil waitUntil, ShortTermRetentionPolicyName policyName, BackupShortTermRetentionPolicyData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _backupShortTermRetentionPolicyRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, parameters, cancellationToken);
                var operation = new SqlArmOperation<BackupShortTermRetentionPolicyResource>(new BackupShortTermRetentionPolicyOperationSource(Client), _backupShortTermRetentionPolicyClientDiagnostics, Pipeline, _backupShortTermRetentionPolicyRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BackupShortTermRetentionPolicyResource>> GetAsync(ShortTermRetentionPolicyName policyName, CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = await _backupShortTermRetentionPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BackupShortTermRetentionPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BackupShortTermRetentionPolicyResource> Get(ShortTermRetentionPolicyName policyName, CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.Get");
            scope.Start();
            try
            {
                var response = _backupShortTermRetentionPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new BackupShortTermRetentionPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies
        /// Operation Id: BackupShortTermRetentionPolicies_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="BackupShortTermRetentionPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<BackupShortTermRetentionPolicyResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<BackupShortTermRetentionPolicyResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _backupShortTermRetentionPolicyRestClient.ListByDatabaseAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BackupShortTermRetentionPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<BackupShortTermRetentionPolicyResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _backupShortTermRetentionPolicyRestClient.ListByDatabaseNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new BackupShortTermRetentionPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a database&apos;s short term retention policy.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies
        /// Operation Id: BackupShortTermRetentionPolicies_ListByDatabase
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="BackupShortTermRetentionPolicyResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<BackupShortTermRetentionPolicyResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<BackupShortTermRetentionPolicyResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _backupShortTermRetentionPolicyRestClient.ListByDatabase(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BackupShortTermRetentionPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<BackupShortTermRetentionPolicyResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _backupShortTermRetentionPolicyRestClient.ListByDatabaseNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new BackupShortTermRetentionPolicyResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(ShortTermRetentionPolicyName policyName, CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(policyName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(ShortTermRetentionPolicyName policyName, CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(policyName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<BackupShortTermRetentionPolicyResource>> GetIfExistsAsync(ShortTermRetentionPolicyName policyName, CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _backupShortTermRetentionPolicyRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<BackupShortTermRetentionPolicyResource>(null, response.GetRawResponse());
                return Response.FromValue(new BackupShortTermRetentionPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}/backupShortTermRetentionPolicies/{policyName}
        /// Operation Id: BackupShortTermRetentionPolicies_Get
        /// </summary>
        /// <param name="policyName"> The policy name. Should always be &quot;default&quot;. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<BackupShortTermRetentionPolicyResource> GetIfExists(ShortTermRetentionPolicyName policyName, CancellationToken cancellationToken = default)
        {
            using var scope = _backupShortTermRetentionPolicyClientDiagnostics.CreateScope("BackupShortTermRetentionPolicyCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _backupShortTermRetentionPolicyRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, policyName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<BackupShortTermRetentionPolicyResource>(null, response.GetRawResponse());
                return Response.FromValue(new BackupShortTermRetentionPolicyResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<BackupShortTermRetentionPolicyResource> IEnumerable<BackupShortTermRetentionPolicyResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<BackupShortTermRetentionPolicyResource> IAsyncEnumerable<BackupShortTermRetentionPolicyResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
