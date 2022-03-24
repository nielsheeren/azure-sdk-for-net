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

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="SqlDatabaseResource" /> and their operations.
    /// Each <see cref="SqlDatabaseResource" /> in the collection will belong to the same instance of <see cref="SqlServerResource" />.
    /// To get a <see cref="SqlDatabaseCollection" /> instance call the GetSqlDatabases method from an instance of <see cref="SqlServerResource" />.
    /// </summary>
    public partial class SqlDatabaseCollection : ArmCollection, IEnumerable<SqlDatabaseResource>, IAsyncEnumerable<SqlDatabaseResource>
    {
        private readonly ClientDiagnostics _sqlDatabaseDatabasesClientDiagnostics;
        private readonly DatabasesRestOperations _sqlDatabaseDatabasesRestClient;

        /// <summary> Initializes a new instance of the <see cref="SqlDatabaseCollection"/> class for mocking. </summary>
        protected SqlDatabaseCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SqlDatabaseCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal SqlDatabaseCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _sqlDatabaseDatabasesClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", SqlDatabaseResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SqlDatabaseResource.ResourceType, out string sqlDatabaseDatabasesApiVersion);
            _sqlDatabaseDatabasesRestClient = new DatabasesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, sqlDatabaseDatabasesApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != SqlServerResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, SqlServerResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a new database or updates an existing database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="parameters"> The requested database resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual async Task<ArmOperation<SqlDatabaseResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string databaseName, SqlDatabaseData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _sqlDatabaseDatabasesRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, parameters, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<SqlDatabaseResource>(new SqlDatabaseOperationSource(Client), _sqlDatabaseDatabasesClientDiagnostics, Pipeline, _sqlDatabaseDatabasesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a new database or updates an existing database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> "F:Azure.WaitUntil.Completed" if the method should wait to return until the long-running operation has completed on the service; "F:Azure.WaitUntil.Started" if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="parameters"> The requested database resource state. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> or <paramref name="parameters"/> is null. </exception>
        public virtual ArmOperation<SqlDatabaseResource> CreateOrUpdate(WaitUntil waitUntil, string databaseName, SqlDatabaseData parameters, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));
            Argument.AssertNotNull(parameters, nameof(parameters));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _sqlDatabaseDatabasesRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, parameters, cancellationToken);
                var operation = new SqlArmOperation<SqlDatabaseResource>(new SqlDatabaseOperationSource(Client), _sqlDatabaseDatabasesClientDiagnostics, Pipeline, _sqlDatabaseDatabasesRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, parameters).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_Get
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual async Task<Response<SqlDatabaseResource>> GetAsync(string databaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.Get");
            scope.Start();
            try
            {
                var response = await _sqlDatabaseDatabasesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlDatabaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a database.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_Get
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual Response<SqlDatabaseResource> Get(string databaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.Get");
            scope.Start();
            try
            {
                var response = _sqlDatabaseDatabasesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SqlDatabaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of databases.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases
        /// Operation Id: Databases_ListByServer
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SqlDatabaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SqlDatabaseResource> GetAllAsync(string skipToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<SqlDatabaseResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseDatabasesRestClient.ListByServerAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SqlDatabaseResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _sqlDatabaseDatabasesRestClient.ListByServerNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets a list of databases.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases
        /// Operation Id: Databases_ListByServer
        /// </summary>
        /// <param name="skipToken"> The String to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SqlDatabaseResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SqlDatabaseResource> GetAll(string skipToken = null, CancellationToken cancellationToken = default)
        {
            Page<SqlDatabaseResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseDatabasesRestClient.ListByServer(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SqlDatabaseResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _sqlDatabaseDatabasesRestClient.ListByServerNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, skipToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new SqlDatabaseResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_Get
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string databaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(databaseName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_Get
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual Response<bool> Exists(string databaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(databaseName, cancellationToken: cancellationToken);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_Get
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual async Task<Response<SqlDatabaseResource>> GetIfExistsAsync(string databaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _sqlDatabaseDatabasesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<SqlDatabaseResource>(null, response.GetRawResponse());
                return Response.FromValue(new SqlDatabaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/servers/{serverName}/databases/{databaseName}
        /// Operation Id: Databases_Get
        /// </summary>
        /// <param name="databaseName"> The name of the database. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="databaseName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="databaseName"/> is null. </exception>
        public virtual Response<SqlDatabaseResource> GetIfExists(string databaseName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(databaseName, nameof(databaseName));

            using var scope = _sqlDatabaseDatabasesClientDiagnostics.CreateScope("SqlDatabaseCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _sqlDatabaseDatabasesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, databaseName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<SqlDatabaseResource>(null, response.GetRawResponse());
                return Response.FromValue(new SqlDatabaseResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SqlDatabaseResource> IEnumerable<SqlDatabaseResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SqlDatabaseResource> IAsyncEnumerable<SqlDatabaseResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
